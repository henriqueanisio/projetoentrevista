using HenriqueAnisio.Domain.Models;

namespace HenriqueAnisio.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}