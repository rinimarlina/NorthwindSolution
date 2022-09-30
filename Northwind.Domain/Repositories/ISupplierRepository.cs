using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSupplier(bool trackChanges);
        Task<Supplier> GetSupplierById(int supplierId, bool trackChanges);
        //Task<IEnumerable<Supplier>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);
        void Insert(Supplier supplier);
        void Edit(Supplier supplier);
        void Remove(Supplier supplier);
    }
}
