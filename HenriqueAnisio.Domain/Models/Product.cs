namespace HenriqueAnisio.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public List<Category> Categories { get; set; } = new();
    }
}
