using AutoMapper;
using OpticSoftware.Authentication;
using OpticSoftware.BLL.Operation.SystemOperations;
using OpticSoftware.Constans;
using OpticSoftware.DAL.Abstract.Company;
using OpticSoftware.DAL.Abstract.User;
using OpticSoftware.Entity.Entities.User;
using OpticSoftware.Enums;
using OpticSoftware.Extensions.BLL.User;
using OpticSoftware.Models.API.User.Request;
using OpticSoftware.Models.API.User.Response;
using OpticSoftware.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.BLL.Operation.UserOperations
{
    // AuthenticationOperations
    public partial class UserOperations
    {
        public partial class AuthenticationOperations
        {
            private readonly IMapper _mapper;
            private readonly IUserService _userService;
            private readonly IUserDetailService _userDetailService;
            private readonly ICompanyService _companyService;
            private readonly IHash _hash;
            private AuthenticationOperationValidator _authenticationOperationValidator;
            private SystemParameterOperations _systemParameterOperations;
            private JWTHelper _jwtHelper;

            public AuthenticationOperations(IUserService userService, IUserDetailService userDetailService, IHash hash, AuthenticationOperationValidator authenticationOperationValidator, IMapper mapper, JWTHelper jwtHelper, ICompanyService companyService, SystemParameterOperations systemParameterOperations)
            {
                _userService = userService;
                _userDetailService = userDetailService;
                _hash = hash;
                _authenticationOperationValidator = authenticationOperationValidator;
                _mapper = mapper;
                _jwtHelper = jwtHelper;
                _companyService = companyService;
                _systemParameterOperations = systemParameterOperations;
            }

            public async Task<LoginResponse> LoginAsync(LoginRequest request)
            {
                LoginResponse response = new LoginResponse()
                {
                    IsSuccess = true,
                    ErrorMessage = ""
                };

                var user = 
                    await _userService.FirstOrDefaultAsync((x => x.Username == request.Username && x.Password == _hash.Hash(request.Password)), "UserDetails");

                if (user != null)
                    user.GetUserDetail().Company = await _companyService.FirstOrDefaultAsync(x => x.ID == user.GetUserDetail().CompanyID);

                var loginValidation = await _authenticationOperationValidator.ValidateUserForLoginAsync(
                        user: user
                    );

                if (loginValidation.ContainsKey(false))
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = loginValidation.GetErrorMessage();
                }

                if (response.IsSuccess)
                {
                    response.JWT = _jwtHelper.GenerateJWT(
                            userId: user.ID,
                            companyId: user.GetUserDetail().CompanyID,
                            role: user.GetUserDetail().Roles,
                            language: user.Language
                        );
                }

                return response;
            }


            public async Task<RegisterResponse> RegisterAsync(RegisterRequest request, long userId, long companyId)
            {
                RegisterResponse response = new RegisterResponse()
                {
                    IsSuccess = true,
                    ErrorMessage = ""
                };

                var requestedUser = await _userService.FirstOrDefaultAsync(x => x.ID == userId, "UserDetails");

                var registerValidation = await _authenticationOperationValidator.ValidateForRegisterAsync(
                        user: requestedUser,
                        username: request.Username
                    );

                if (registerValidation.ContainsKey(false))
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = registerValidation.GetErrorMessage();
                }

                if (response.IsSuccess)
                {
                    UserEntity user = _mapper.Map<RegisterRequest, UserEntity>(request);
                    user.Language = await GetDefaultSystemLanguageAsync();
                    await _userService.AddAsync(user);
                    await _userService.SaveChangesAsync();

                    user = await _userService.FirstOrDefaultAsync(x => x.Username == request.Username);

                    UserDetailEntity userDetail = _mapper.Map<RegisterRequest, UserDetailEntity>(request);
                    userDetail.CompanyID = companyId;
                    userDetail.UserID = user.ID;

                    await _userDetailService.AddAsync(userDetail);
                    await _userDetailService.SaveChangesAsync();
                }

                return response;
            }

            private async Task<LanguageEnum> GetDefaultSystemLanguageAsync()
            {
                var defaultSystemLanguage = await _systemParameterOperations.GetSystemParameterAsync(parameterName: Constants.SystemParameterConstants.DefaultLanguageKey);
                return (LanguageEnum)Enum.Parse(typeof(LanguageEnum), defaultSystemLanguage.ParameterValue);
            }

        }
    }
}
