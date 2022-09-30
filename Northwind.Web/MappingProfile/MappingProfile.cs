using AutoMapper;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Category;
using NorthwindContracts.Dto.Product;
using NorthwindContracts.Dto.Supplier;

namespace Northwind.Web.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForCreateDto>().ReverseMap();

            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierForCreateDto>().ReverseMap();

            CreateMap<ProductPhoto, ProductPhotoDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoCreateDto>().ReverseMap();

        }
    }
}
