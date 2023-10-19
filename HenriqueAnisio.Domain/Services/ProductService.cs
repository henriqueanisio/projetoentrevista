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

        public async Task<Product> GetProductByIdWithCategoriesAsync(Guid id)
        {
            return await _productRepository.GetByIdWithIncludeAsync(x => x.Id == id, x => x.Categories);
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

        public async Task UpdateProductAsync(Product product, List<Guid> idsCategories)
        {
            var categories = await _categoryRepository.GetAsync(x => idsCategories.Contains(x.Id));

            var entity = await _productRepository.GetByIdWithIncludeAsync(x => x.Id == product.Id, x => x.Categories);

            foreach (var existingCategory in entity.Categories)
            {
                if (!categories.Contains(existingCategory))
                {
                    product.Categories.Remove(existingCategory);
                }
            }

            // Adicione as novas categorias ao produto, mas verifique se já não existe uma relação
            foreach (var category in categories)
            {
                if (!entity.Categories.Any(c => c.Id == category.Id))
                {
                    product.Categories.Add(category);
                }
            }

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
