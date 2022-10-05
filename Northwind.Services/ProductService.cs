using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindContracts.Dto.Product;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Category;
using NorthwindContracts.Dto.Order;
using NorthwindContracts.Dto.OrderDetail;

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

        public void CreateOrder(OrderForCreateDto orderForCreateDto, OrderDetailForCreateDto orderDetailForCreateDto)
        {
            //insert order
            var order = _mapper.Map<Order>(orderForCreateDto);
            _repositoryManager.OrderRepository.Insert(order);
            _repositoryManager.Save();

            //insert order detail
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailForCreateDto);
            orderDetail.OrderId = order.OrderId;
            _repositoryManager.OrderDetailRepository.Insert(orderDetail);
            _repositoryManager.Save();
        }

        public void Edit(ProductDto productDto)
        {
            var edit = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public void EditProductPhoto(ProductDto productDto, List<ProductPhotoDto> productPhotoDto)
        {
            //insert product
            var productModel = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(productModel);
            _repositoryManager.Save();

            //insert photo product
            foreach (var item in productPhotoDto)
            {
                item.PhotoProductId = productModel.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Edit(photoModel);
            }
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
            var productModel = await _repositoryManager.ProductRepository.GetProductById(productId, trackChanges);
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductPaged(pageIndex, pageSize, trackChanges);

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
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

        public async Task<IEnumerable<ProductDto>> GetProductOnSale(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductOnSale(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductDto> GetProductOnSaleById(int productOnSaleId, bool trackChanges)
        {
            var productOnSaleModel = await _repositoryManager.ProductRepository.GetProductOnSaleById(productOnSaleId, trackChanges);
            var productOnSaleDto = _mapper.Map<ProductDto>(productOnSaleModel);
            return productOnSaleDto;
        }

        public async Task<ProductOrderGroupDto> GetProductOrderOnSaleById(int productOrderOnSaleId, bool trackChanges)
        {
            var productOrderOnSaleModel = await _repositoryManager.ProductRepository.GetProductOrderOnSaleById(productOrderOnSaleId, trackChanges);
            var producOrderOnSaleDto = _mapper.Map<ProductOrderGroupDto>(productOrderOnSaleModel);
            return producOrderOnSaleDto;
        }

        public async Task<ProductPhotoGroupDto> GetProductPhotoGroupById(int productPhotoId, bool trackChanges)
        {
            var productPhotoGroupModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(productPhotoId, trackChanges);
            var producPhotoGroupDto = _mapper.Map<ProductPhotoGroupDto>(productPhotoGroupModel);
            return producPhotoGroupDto;
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
    }
}