using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindContracts.Dto.Product;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Category;

namespace Northwind.Services
{
    public class ProductService : IProductService
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        // dependency injection
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ProductDto CreateProductId(ProductForCreateDto productForCreateDto)
        {
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();

            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public void Edit(ProductDto productDto)
        {
            var edit = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetAllProduct(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductDto> GetProductById(int productId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductById(productId,trackChanges);
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductPaged(pageIndex,pageSize,trackChanges);

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public void Insert(ProductForCreateDto productForCreateDto)
        {
            var insert = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(ProductDto productDto)
        {
            var remove = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Remove(remove);
            _repositoryManager.Save();
        }

        public void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoCreateDto> productPhotoCreateDtos)
        {
            // 1. Insert into table product
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();

            // insert into table productPhotos
            foreach (var item in productPhotoCreateDtos)
            {
                item.PhotoProductId = productModel.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Insert(photoModel);
            }
            _repositoryManager.Save();
        }
    }
}