using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Models.API.Product.Response
{
    public class GetProductsByCategoryResponse : BaseResponse
    {
        public IEnumerable<ProductEntity> Products { get; set; }
    }
}
