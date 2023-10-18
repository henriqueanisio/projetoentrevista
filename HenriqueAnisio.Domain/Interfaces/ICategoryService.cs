using HenriqueAnisio.Domain.Models;

namespace HenriqueAnisio.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task InsertCategoryAsync(Category category);
    }
}