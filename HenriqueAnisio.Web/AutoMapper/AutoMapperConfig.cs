using AutoMapper;
using HenriqueAnisio.Domain.Models;
using HenriqueAnisio.Web.ViewModels;

namespace HenriqueAnisio.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
