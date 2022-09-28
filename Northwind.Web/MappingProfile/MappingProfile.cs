using AutoMapper;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Category;
using NorthwindContracts.Dto.Product;

namespace Northwind.Web.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForCreateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

        }
    }
}
