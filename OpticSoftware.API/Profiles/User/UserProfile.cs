using AutoMapper;
using OpticSoftware.Entity.Entities.User;
using OpticSoftware.Models.API.User.Request;
using OpticSoftware.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpticSoftware.API.Profiles.User
{
    public class UserProfile : Profile
    {
        public UserProfile(IHash hash)
        {
            CreateMap<RegisterRequest, UserEntity>()
                .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(x => x.Password, opt => opt.MapFrom(src => hash.Hash(src.Password)))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => true))
                .ReverseMap();

            CreateMap<RegisterRequest, UserDetailEntity>().ReverseMap();
        }
    }
}
