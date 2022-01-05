using AutoMapper;
using OpticSoftware.BLL.Operation.SystemOperations;
using OpticSoftware.DAL.Abstract.Product;
using OpticSoftware.Enums;
using OpticSoftware.Models.API.Product.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpticSoftware.BLL.Operation.ProductOperations
{
    public class ProductCategoryOperationValidator : BaseValidator
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryOperationValidator(IProductCategoryService productCategoryService, IMapper mapper, SystemParameterOperations systemParameterOperations) : base(systemParameterOperations)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<Dictionary<bool, string>> ValidateForAddProductAsync(AddProductCategoryRequest request, long companyID)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();

            var control = await _productCategoryService.FirstOrDefaultAsync(x => x.Name == request.Name && x.CompanyID == companyID);

            LanguageEnum language = await this.GetDefaultSystemLanguageAsync();

            if (control != null)
            {
                if (language == LanguageEnum.TR)
                {
                    result.Add(false, "Eklemek istediğiniz ürün kategorisi mevcut.");
                }
                else if (language == LanguageEnum.EN)
                {
                    result.Add(false, "This product category is already exists.");
                }
            }
            else
            {
                result.Add(true, string.Empty);
            }

            return result;
        }

    }
}
