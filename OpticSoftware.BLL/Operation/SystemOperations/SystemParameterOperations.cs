using OpticSoftware.DAL.Abstract;
using OpticSoftware.Entity.Entities;
using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.BLL.Operation.SystemOperations
{
    public class SystemParameterOperations
    {
        private readonly ISystemParameterService _systemParameterService;

        public SystemParameterOperations(ISystemParameterService systemParameterService)
        {
            _systemParameterService = systemParameterService;
        }

        public async Task<SystemParameterEntity> GetSystemParameterAsync(string parameterName)
        {
            var result = await _systemParameterService.FirstOrDefaultAsync(x => x.ParameterName == parameterName);
            return result;
        }
    }
}
