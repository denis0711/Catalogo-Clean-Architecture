using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Applictation.DTOs
{
    public class CategoriaDTO
    {

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage ="O campo {0} deve ter entre {2} a {1}", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(250, ErrorMessage = "O campo {0} deve ter entre {2} a {1}", MinimumLength = 3)]
        public string ImagemUrl { get; set; }


    }
}
