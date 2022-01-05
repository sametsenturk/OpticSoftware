using OpticSoftware.BLL.Operation.SystemOperations;
using OpticSoftware.Constans;
using OpticSoftware.DAL.Abstract.User;
using OpticSoftware.Entity.Entities.User;
using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.BLL.Operation.UserOperations
{
    public class AuthenticationOperationValidator : BaseValidator
    {
        private readonly IUserService _userService;

        public AuthenticationOperationValidator(IUserService userService, SystemParameterOperations systemParameterOperations) : base(systemParameterOperations)
        {
            _userService = userService;           
        }

        public async Task<Dictionary<bool, string>> ValidateUserForLoginAsync(UserEntity user)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();

            LanguageEnum language = await this.GetDefaultSystemLanguageAsync();

            if (user == null)
            {
                if (language == LanguageEnum.TR)
                {
                    result.Add(false, "Kullanıcı adı veya şifreniz yanlıştır.");
                }
                else if (language == LanguageEnum.EN)
                {
                    result.Add(false, "Wrong username or password.");
                }
            }
            else
            {
                if (!user.GetUserDetail().Company.IsActive)
                {
                    if (language == LanguageEnum.TR)
                    {
                        result.Add(false, "Bağlı bulunduğunuz kurumun sisteme erişimi kapatılmıştır.");
                    }
                    else if (language == LanguageEnum.EN)
                    {
                        result.Add(false, "Your company don't have permission to access system.");
                    }
                }

                if (!user.IsActive)
                {
                    if (language == LanguageEnum.TR)
                    {
                        result.Add(false, "Hesabınız kullanıma kapatılmıştır.");
                    }
                    else if (language == LanguageEnum.EN)
                    {
                        result.Add(false, "Your account has been closed to access the system.");
                    }
                }

                if (user.GetUserDetail().Company.ExpireDate < DateTime.Now)
                {
                    if (user.GetUserDetail().UserType == UserTypeEnum.Boss)
                    {
                        if (language == LanguageEnum.TR)
                        {
                            result.Add(false, "Üyeliğinizin süresi dolduğu için sisteme erişiminiz kapatılmıştır. Sistem yöneticisi ile iletişime geçiniz.");
                        }
                        else if (language == LanguageEnum.EN)
                        {
                            result.Add(false, "Your system access is closed because of end of your subscription. Please contact with system administrator.");
                        }
                    }
                    else if (user.GetUserDetail().UserType == UserTypeEnum.Employee)
                    {
                        if (language == LanguageEnum.TR)
                        {
                            result.Add(false, "Sisteme erişiminiz kapatılmıştır. Konu ile alakalı yöneticiniz ile iletişime geçebilirsiniz.");
                        }
                        else if (language == LanguageEnum.EN)
                        {
                            result.Add(false, "Your system access has been closed. You can contact with your manager about this situation.");
                        }
                    }
                }
            }

            return result;
        }

        public async Task<Dictionary<bool, string>> ValidateForRegisterAsync(UserEntity user, string username)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();

            LanguageEnum language = user.Language;

            //if (user.GetUserDetail().UserType != UserTypeEnum.Boss)
            //{
            //    if (language == LanguageEnum.TR)
            //    {
            //        result.Add(false, "Kullanıcı oluşturmak için yetkiniz yoktur.");
            //    }
            //    else if (language == LanguageEnum.EN)
            //    {
            //        result.Add(false, "You don't have permission to create user.");
            //    }
            //}
            //else
            //{
            //}

            var control = await _userService.FirstOrDefaultAsync(x => x.Username == username);

            if (control != null)
            {
                if (language == LanguageEnum.TR)
                {
                    result.Add(false, "Kullanıcı adı sistemde kayıtlı. Başka bir kullanıcı adı deneyin.");
                }
                else if (language == LanguageEnum.EN)
                {
                    result.Add(false, "Username is already registered to system. Try with another username.");
                }
            }
            else
            {
                result.Add(true, string.Empty);
            }

            return result;
        }

       

    }
}
