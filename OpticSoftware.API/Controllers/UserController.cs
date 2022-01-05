using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpticSoftware.Attributes;
using OpticSoftware.Enums;
using OpticSoftware.Models.API.User.Request;
using OpticSoftware.Models.API.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OpticSoftware.BLL.Operation.UserOperations.UserOperations;

namespace OpticSoftware.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly AuthenticationOperations _authenticationOperations;
        public UserController(AuthenticationOperations authenticationOperations)
        {
            _authenticationOperations = authenticationOperations;
        }

        [AllowAnonymous, HttpPost, Route("login")]
        public async Task<LoginResponse> LoginAsync([FromBody] LoginRequest request)
        {
            return await _authenticationOperations.LoginAsync(
                    request: request
                );
        }


        [Authorize, HttpPost, Route("register"), RequiredRole(UserPermissionEnum.AddUser)]
        public async Task<RegisterResponse> RegisterAsync([FromBody] RegisterRequest request)
        {
            return await _authenticationOperations.RegisterAsync(
                    request: request,
                    userId: this.GetCurrentUserID(),
                    companyId: this.GetCurrentUserCompanyID()
                );
        }


    }
}
