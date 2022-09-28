using AutoMapper;
using NorthwindContracts.Dto.Category;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Product;

namespace Northwind.Test.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, ProductForCreateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

        }
    }
}
