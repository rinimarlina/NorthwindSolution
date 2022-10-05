
using NorthwindContracts.Dto.Category;
using NorthwindContracts.Dto.Order;
using NorthwindContracts.Dto.OrderDetail;
using NorthwindContracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Northwind.Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);

        Task<ProductDto> GetProductById(int productId, bool trackChanges);
        Task<ProductOrderGroupDto> GetProductOrderOnSaleById(int productOrderOnSaleId, bool trackChanges);
        Task<ProductPhotoGroupDto> GetProductPhotoGroupById(int productPhotoId, bool trackChanges);
        Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);
        Task<IEnumerable<ProductDto>> GetProductOnSale(bool trackChanges);
        Task<ProductDto> GetProductOnSaleById(int productOnSaleId, bool trackChanges);
        ProductDto CreateProductId(ProductForCreateDto productForCreateDto);

        void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoCreateDto> productPhotoCreateDtos);
        void CreateOrder(OrderForCreateDto orderForCreateDto, OrderDetailForCreateDto orderDetailForCreateDto);
        void Insert(ProductForCreateDto productForCreateDto);
        void EditProductPhoto(ProductDto productDto, List<ProductPhotoDto> productPhotoDto);

        void Edit(ProductDto productDto);

        void Remove(ProductDto productDto);
    }
}
