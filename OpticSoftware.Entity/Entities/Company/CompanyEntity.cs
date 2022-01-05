using OpticSoftware.Entity.Entities.Company;
using OpticSoftware.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Entities.Company
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public int SMSCount { get; set; }

        public virtual List<UserDetailEntity> UserDetails { get; set; }
        public virtual List<CompanyParameterEntity> CompanyParameters { get; set; }
    }
}
