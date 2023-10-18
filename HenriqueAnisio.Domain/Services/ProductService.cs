using HenriqueAnisio.Domain.Interfaces;
using HenriqueAnisio.Domain.Models;

namespace HenriqueAnisio.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductService(IRepository<Product> productRepository,
             IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategoriesAsync()
        {
            return await _productRepository.GetAllWithIncludeAsync(x => x.Categories);
        }

        public async Task InsertProductAsync(Product product, List<Guid> idsCategories)
        {
            await _productRepository.InsertAsync(product);

            if(idsCategories.Any()) {
                foreach (var IdCategory in idsCategories)
                {
                    var category = await _categoryRepository.GetById(IdCategory);
                    category.Products.Add(product);
                    await _categoryRepository.SaveChangesAsync();
                }
            }
        }
    }
}
