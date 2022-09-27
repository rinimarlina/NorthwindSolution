using AutoMapper;
using NorthwindContracts.Dto.Category;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Category;

namespace Northwind.Test.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForCreateDto>().ReverseMap();

        }
    }
}
