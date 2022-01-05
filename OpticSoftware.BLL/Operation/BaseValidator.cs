using OpticSoftware.BLL.Operation.SystemOperations;
using OpticSoftware.Constans;
using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.BLL.Operation
{
    public class BaseValidator
    {
        private SystemParameterOperations _systemParameterOperations;

        public BaseValidator(SystemParameterOperations systemParameterOperations)
        {
            _systemParameterOperations = systemParameterOperations;
        }

        protected async Task<LanguageEnum> GetDefaultSystemLanguageAsync()
        {
            var defaultSystemLanguage = await _systemParameterOperations.GetSystemParameterAsync(parameterName: Constants.SystemParameterConstants.DefaultLanguageKey);
            return (LanguageEnum)Enum.Parse(typeof(LanguageEnum), defaultSystemLanguage.ParameterValue);
        }
    }
}
