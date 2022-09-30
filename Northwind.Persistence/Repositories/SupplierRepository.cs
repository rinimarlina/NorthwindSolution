using Microsoft.EntityFrameworkCore;
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
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Supplier supplier)
        {
            Update(supplier);
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CompanyName).ToListAsync();
        }

        public async Task<Supplier> GetSupplierById(int supplierId, bool trackChanges)
        {
            return await FindByCondition(c => c.SupplierId.Equals(supplierId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Supplier supplier)
        {
            Create(supplier);
        }

        public void Remove(Supplier supplier)
        {
            Delete(supplier);
        }
    }
}
