using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HenriqueAnisio.Web.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [DisplayName("Preço")]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Preço inválido. Use um formato válido, por exemplo, 12,40.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Decimal Price { get; set; }

        public List<Guid> IdsCategories { get; set; } = new();

        [DisplayName("Categorias")]
        public List<CategoryViewModel> Categories { get; set; } = new();
    }
}
