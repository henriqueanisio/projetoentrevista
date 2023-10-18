using HenriqueAnisio.Domain.Models;

namespace HenriqueAnisio.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsWithCategoriesAsync();
        Task InsertProductAsync(Product product, List<Guid> idsCategories);
    }
}