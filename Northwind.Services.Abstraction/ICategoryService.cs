using NorthwindContracts.Dto;
using NorthwindContracts.Dto.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryDto = NorthwindContracts.Dto.Category.CategoryDto;

namespace Northwind.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategory(bool trackChanges);

        Task<CategoryDto> GetCategoryById(int categoryId, bool trackChanges);

        void Insert(CategoryForCreateDto categoryForCreateDto);

        void Edit(CategoryDto categoryDto);

        void Remove(CategoryDto categoryDto);
    }
}
