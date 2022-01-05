using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiredRoleAttribute : ActionFilterAttribute
    {
        private UserPermissionEnum[] _requiredRoles;

        public RequiredRoleAttribute(params UserPermissionEnum[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string roleClaimValue = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            if(string.IsNullOrEmpty(roleClaimValue) || string.IsNullOrWhiteSpace(roleClaimValue))
            {
                context.Result = new BadRequestResult(); // bye
            }
            else
            {
                Parallel.ForEach(_requiredRoles, (requiredRole) =>
                {                    
                    if (roleClaimValue.Split(';').FirstOrDefault(x => x == ((int)requiredRole).ToString()) == null)
                    {
                        context.Result = new UnauthorizedResult(); // unauthorized                        
                    }
                });
            }          
        }
    }
}
