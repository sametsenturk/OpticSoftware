using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpticSoftware.Models.API.User.Request
{
    public class RegisterRequest : BaseRequest
    {
        [MaxLength(25), DataType(DataType.Text), Required]
        public string Username { get; set; }

        [MaxLength(25), DataType(DataType.Password), Required]
        public string Password { get; set; }

        [MaxLength(25), DataType(DataType.Text), Required]
        public string Name { get; set; }

        [MaxLength(25), DataType(DataType.Text), Required]
        public string Surname { get; set; }

        [MaxLength(25), DataType(DataType.PhoneNumber), Required]
        public string PhoneNumber { get; set; }

        [MaxLength(50), DataType(DataType.Text), Required]
        public string Roles { get; set; }

        [Required]
        public UserTypeEnum UserType { get; set; }
    }
}
