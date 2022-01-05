using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpticSoftware.Models.API.Product.Request
{
    public class AddProductCategoryRequest : BaseRequest
    {
        [MaxLength(30), DataType(DataType.Text), Required]
        public string Name { get; set; }
    }
}
