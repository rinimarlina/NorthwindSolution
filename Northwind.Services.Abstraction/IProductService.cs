
using NorthwindContracts.Dto.Category;
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
        Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);
        ProductDto CreateProductId(ProductForCreateDto productForCreateDto);

        void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoCreateDto> productPhotoCreateDtos);
        void Insert(ProductForCreateDto productForCreateDto);

        void Edit(ProductDto productDto);

        void Remove(ProductDto productDto);
    }
}
