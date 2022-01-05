using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpticSoftware.Entity.Entities.Product
{
    public class ProductCategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public long CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public virtual CompanyEntity Company { get; set; }

        public virtual List<ProductEntity> Products { get; set; }
    }
}
