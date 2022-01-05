using AutoMapper;
using OpticSoftware.DAL.Abstract.Product;
using OpticSoftware.Entity.Entities.Product;
using OpticSoftware.Extensions.BLL.User;
using OpticSoftware.Models.API.Product.Request;
using OpticSoftware.Models.API.Product.Response;
using OpticSoftware.Models.API.User.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.BLL.Operation.ProductOperations
{
    public class ProductCategoryOperations
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;
        private ProductCategoryOperationValidator _productCategoryOperationValidator;

        public ProductCategoryOperations(IProductCategoryService productCategoryService, IMapper mapper, ProductCategoryOperationValidator productCategoryOperationValidator)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
            _productCategoryOperationValidator = productCategoryOperationValidator;
        }

        public async Task<GetProductCategoriesResponse> GetProductCategoriesAsync(long companyID)
        {
            GetProductCategoriesResponse response = new GetProductCategoriesResponse
            {
                IsSuccess = true,
                ErrorMessage = ""
            };

            response.ProductCategories = await _productCategoryService.GetAsync(x => x.CompanyID == companyID);

            return response;
        }

        public async Task<AddProductCategoryResponse> AddProductCategoryAsync(AddProductCategoryRequest request, long companyID)
        {
            AddProductCategoryResponse response = new AddProductCategoryResponse
            {
                IsSuccess = true,
                ErrorMessage = ""
            };

            var addProductValidation = await _productCategoryOperationValidator.ValidateForAddProductAsync(
                        request: request,
                        companyID: companyID
                    );

            if (addProductValidation.ContainsKey(false))
            {
                response.IsSuccess = false;
                response.ErrorMessage = addProductValidation.GetErrorMessage();
            }

            if (response.IsSuccess)
            {
                ProductCategoryEntity productCategory = _mapper.Map<AddProductCategoryRequest, ProductCategoryEntity>(request);
                productCategory.CompanyID = companyID;

                await _productCategoryService.AddAsync(productCategory);
                await _productCategoryService.SaveChangesAsync();
            }

            return response;
        }


    }
}
