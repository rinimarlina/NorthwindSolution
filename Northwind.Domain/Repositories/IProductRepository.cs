﻿using Northwind.Domain.Dto;
using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>>GetAllProduct(bool trackChanges);
        Task<Product> GetProductById(int productId, bool trackChanges);
        Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);
        Task<IEnumerable<Product>> GetProductOnSale(bool trackChanges);
        Task<Product> GetProductOnSaleById(int productOnSaleId, bool trackChanges);
        Task<Product> GetProductOrderOnSaleById(int productOrderOnSaleId, bool trackChanges);

        IEnumerable<TotalProductByCategory> GetTotalProductByCategory();

        void Insert(Product product);
        void Edit(Product product);
        void Remove(Product product);

    }
}
