using AutoMapper;
using OpticSoftware.Entity.Entities.Product;
using OpticSoftware.Models.API.Product.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpticSoftware.API.Profiles.Product
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductCategoryRequest, ProductCategoryEntity>()
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(src => false))
                .ReverseMap();
        }
    }
}
