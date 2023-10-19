using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HenriqueAnisio.Web.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Name { get; set; } = string.Empty;
        public bool Selected { get; set; }

        public List<ProductViewModel> Products { get; set; } = new();
    }
}
