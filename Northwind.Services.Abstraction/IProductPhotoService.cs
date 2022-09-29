using NorthwindContracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IProductPhotoService
    {
        Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges);
        Task<ProductPhotoDto> GetProductPhotoById(int productPhotoId, bool tracChanges);
        Task<IEnumerable<ProductPhotoDto>> GetProductPhotopaged(int pageIndex, int pageSize, bool tracChanges);
        void Insert(ProductPhotoCreateDto productPhotoCreateDto);
        void Edit(ProductPhotoDto productPhotoDto);
        void Remove(ProductPhotoDto productPhotoDto);
    }
}
