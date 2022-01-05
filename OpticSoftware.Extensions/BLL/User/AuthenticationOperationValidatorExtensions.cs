using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.Extensions.BLL.User
{
    public static class AuthenticationOperationValidatorExtensions
    {
        public static string GetErrorMessage(this Dictionary<bool, string> dictionary)
        {
            string message = "";
            Parallel.ForEach(dictionary, (item) =>
            {
                if (!item.Key && item.Value != string.Empty)
                {
                    message += item.Value + " \n ";
                }
            });
            return message;
        }
    }
}
