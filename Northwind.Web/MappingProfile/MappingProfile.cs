using AutoMapper;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Authentication;
using NorthwindContracts.Dto.Category;
using NorthwindContracts.Dto.Order;
using NorthwindContracts.Dto.OrderDetail;
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
            CreateMap<ProductPhoto, ProductPhotoGroupDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderForCreateDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailForCreateDto>().ReverseMap();

            CreateMap<UserRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<UserLoginDto, User>().ReverseMap();
        }
    }
}
