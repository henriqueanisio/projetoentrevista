using HenriqueAnisio.Domain.Interfaces;
using HenriqueAnisio.Domain.Models;

namespace HenriqueAnisio.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _categoryRepository.InsertAsync(category);
        }
    }
}
