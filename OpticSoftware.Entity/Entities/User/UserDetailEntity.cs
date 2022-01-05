using OpticSoftware.Entity.Entities.Company;
using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpticSoftware.Entity.Entities.User
{
    public class UserDetailEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; }
        public UserTypeEnum UserType { get; set; }


        public long UserID  { get; set; }
        public long CompanyID { get; set; }


        [ForeignKey("UserID")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("CompanyID")]
        public virtual CompanyEntity Company { get; set; }
    }
}
