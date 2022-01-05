using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpticSoftware.Models.API.User.Request
{
    public class LoginRequest : BaseRequest
    {
        [MaxLength(25), DataType(DataType.Text), Required]
        public string Username { get; set; }

        [MaxLength(25), DataType(DataType.Password), Required]
        public string Password { get; set; }
    }
}
