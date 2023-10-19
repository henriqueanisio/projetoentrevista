using HenriqueAnisio.Domain.Models;

namespace HenriqueAnisio.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdWithCategoriesAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsWithCategoriesAsync();
        Task InsertProductAsync(Product product, List<Guid> idsCategories);
        Task UpdateProductAsync(Product product, List<Guid> idsCategories);
        Task DeleteProductAsync(Guid id);
    }
}