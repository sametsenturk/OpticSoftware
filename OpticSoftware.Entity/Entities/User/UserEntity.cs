using OpticSoftware.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpticSoftware.Entity.Entities.User
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public LanguageEnum Language { get; set; }

        public virtual List<UserDetailEntity> UserDetails { get; set; }


        public UserDetailEntity GetUserDetail()
        {
            return this.UserDetails.First();
        }
    }
}
