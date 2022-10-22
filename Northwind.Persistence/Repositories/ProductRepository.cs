using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Dto;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Product product)
        {
            Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllProduct(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Include(a => a.ProductPhotos)
                .ToListAsync();
        }


        public async Task<Product> GetProductById(int productId, bool trackChanges)
        {
            return await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Include(a => a.ProductPhotos)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductOnSale(bool trackChanges)
        {
            var products = await _dbContext.Products
                .Where(x => x.ProductPhotos
                .Any(y => y.PhotoProductId == x.ProductId))
                .Include(p => p.ProductPhotos)
                .ToListAsync();
            /*var products = await FindAll(trackChanges)
                .Include(x => x.ProductPhotos.SingleOrDefault())
                .ToListAsync();*/
            return products;
        }

        public async Task<Product> GetProductOnSaleById(int productOnSaleId, bool trackChanges)
        {
            var productOnSale = await FindByCondition (p => p.ProductId.Equals(productOnSaleId), trackChanges)
                .Where(x => x.ProductPhotos
                .Any(y => y.PhotoProductId == productOnSaleId))
                .Include(p => p.ProductPhotos)
                .SingleOrDefaultAsync();
            return productOnSale;
        }

        public async Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Include(a => a.ProductPhotos)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product>GetProductOrderOnSaleById(int productOrderOnSaleId, bool trackChanges)
        {
            var products = await FindByCondition(x => x.ProductId.Equals(productOrderOnSaleId), trackChanges)
                .Where(y => y.ProductPhotos.Any(p => p.PhotoProductId == productOrderOnSaleId))
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Include(o => o.OrderDetails)
                .Include(a => a.ProductPhotos)
                .SingleOrDefaultAsync();
            return products;
        }

        public void Insert(Product product)
        {
            Create(product);
        }


        public void Remove(Product product)
        {
            Delete(product);
        }

        public IEnumerable<TotalProductByCategory> GetTotalProductByCategory()
        {
            //var pName = new Sql
            var rowSQL =  _dbContext.TotalProductByCategorySQL
                .FromSqlRaw("select c.CategoryName,count(p.ProductId)TotalProduct " +
                "from Products p join Categories c on p.CategoryID = c.CategoryID " +
                "group by c.CategoryName")
                .Select(x => new TotalProductByCategory
                {
                    CategoryName = x.CategoryName,
                    TotalProduct = x.TotalProduct
                })
                .OrderBy(x => x.TotalProduct)
                .ToList();

            return rowSQL;
        }
    }
}
