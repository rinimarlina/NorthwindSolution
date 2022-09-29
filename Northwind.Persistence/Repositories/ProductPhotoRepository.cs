﻿using Microsoft.EntityFrameworkCore;
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
    public class ProductPhotoRepository : RepositoryBase<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(ProductPhoto productPhoto)
        {
            Update(productPhoto);
        }

        public async Task<IEnumerable<ProductPhoto>> GetAllProductPhoto(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.PhotoId)
                .Include(s => s.PhotoProduct)
                .ToListAsync();
        }

        public async Task<ProductPhoto> GetProductPhotoById(int productPhotoId, bool trackChanges)
        {
            return await FindByCondition(p => p.PhotoId.Equals(productPhotoId), trackChanges)
                .Include(s => s.PhotoProduct)
                .SingleOrDefaultAsync();
               
        }

        public async Task<IEnumerable<ProductPhoto>> GetProductPhotoPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p => p.PhotoProductId)
                .Include(s => s.PhotoProduct)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public void Insert(ProductPhoto productPhoto)
        {
            Create(productPhoto);
        }

        public void Remove(ProductPhoto productPhoto)
        {
            Delete(productPhoto);
        }
    }
}
