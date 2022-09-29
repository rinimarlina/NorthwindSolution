using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using NorthwindContracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class ProductPhotoService : IProductPhotoService
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductPhotoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ProductPhotoDto productPhotoDto)
        {
            var edit = _mapper.Map<ProductPhoto>(productPhotoDto);
            _repositoryManager.ProductPhotoRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges)
        {
            var productPhotoModel = await _repositoryManager.ProductPhotoRepository.GetAllProductPhoto(trackChanges);
            var productPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(productPhotoModel);
            return productPhotoDto;
        }

        public async Task<ProductPhotoDto> GetProductPhotoById(int productPhotoId, bool trackChanges)
        {
            var productPhotoModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(productPhotoId, trackChanges);
            var productPhotoDto = _mapper.Map<ProductPhotoDto>(productPhotoModel);
            return productPhotoDto;
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetProductPhotopaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productPhotoModel = await _repositoryManager
                .ProductPhotoRepository.GetProductPhotoPaged(pageIndex, pageSize, trackChanges);

            var productPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(productPhotoModel);
            return productPhotoDto;
        }

        public void Insert(ProductPhotoCreateDto productPhotoCreateDto)
        {
            var insert = _mapper.Map<ProductPhoto>(productPhotoCreateDto);
            _repositoryManager.ProductPhotoRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(ProductPhotoDto productPhotoDto)
        {
            var remove = _mapper.Map<ProductPhoto>(productPhotoDto);
            _repositoryManager.ProductPhotoRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
