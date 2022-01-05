using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Models.API.User.Response
{
    public class LoginResponse : BaseResponse
    {
        public string JWT { get; set; }
    }
}
