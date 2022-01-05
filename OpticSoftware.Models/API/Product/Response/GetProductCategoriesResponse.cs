using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Models.API.Product.Response
{
    public class GetProductCategoriesResponse : BaseResponse
    {
        public IEnumerable<ProductCategoryEntity> ProductCategories  { get; set; }
    }
}
