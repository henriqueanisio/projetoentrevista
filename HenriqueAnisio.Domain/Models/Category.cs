namespace HenriqueAnisio.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();

    }
}
