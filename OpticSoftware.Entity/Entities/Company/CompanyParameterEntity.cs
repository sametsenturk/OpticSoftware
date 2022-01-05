using OpticSoftware.Entity.Entities;
using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpticSoftware.Entity.Entities.Company
{
    public class CompanyParameterEntity : BaseEntity
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }

        public long CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public virtual CompanyEntity Company { get; set; }
    }
}
