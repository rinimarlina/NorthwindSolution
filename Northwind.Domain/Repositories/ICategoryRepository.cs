using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ICategoryRepository
    {
        //trackCange
        Task<IEnumerable<Category>> GetAllCategory(bool trackChanges);
        Task<Category>GetCategoryById(int categoryId,bool trackChanges);
        void Insert(Category category);
        void Edit(Category category);
        void Remove(Category category);


    }
}
