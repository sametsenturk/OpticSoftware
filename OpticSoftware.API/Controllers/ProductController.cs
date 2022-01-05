using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpticSoftware.Attributes;
using OpticSoftware.BLL.Operation.ProductOperations;
using OpticSoftware.Enums;
using OpticSoftware.Models.API.Product.Request;
using OpticSoftware.Models.API.Product.Response;
using OpticSoftware.Models.API.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpticSoftware.API.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly ProductCategoryOperations _productCategoryOperations;

        public ProductController(ProductCategoryOperations productCategoryOperations)
        {
            _productCategoryOperations = productCategoryOperations;
        }


        [RequiredRole(UserPermissionEnum.ListProductCategory), HttpGet, Route("getProductCategories")]
        public async Task<GetProductCategoriesResponse> GetProductCategories()
        {
            return await _productCategoryOperations.GetProductCategoriesAsync(
                    companyID: this.GetCurrentUserCompanyID()
                    );
        }

        [RequiredRole(UserPermissionEnum.AddProductCategory), HttpPost, Route("addProductCategory")]
        public async Task<AddProductCategoryResponse> AddProductCategory([FromBody] AddProductCategoryRequest request)
        {
            return await _productCategoryOperations.AddProductCategoryAsync(
                        request: request,
                        companyID: this.GetCurrentUserCompanyID()
                    );
        }



        //[RequiredRole(UserPermissionEnum.ListProduct)]
        //public async Task<GetProductsByCategoryResponse> GetProductsByCategory(int categoryId)
        //{
        //    return await _productCategoryOperations.GetProductCategoriesAsync(
        //            companyID: this.GetCurrentUserCompanyID()
        //            );
        //}


    }
}
