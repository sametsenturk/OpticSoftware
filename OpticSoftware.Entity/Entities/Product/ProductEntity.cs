using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpticSoftware.Entity.Entities.Product
{
    public class ProductEntity : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }

        public bool IsDeleted { get; set; }

        public long ProductCategoryID { get; set; }

        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategoryEntity ProductCategory { get; set; }
    }
}
