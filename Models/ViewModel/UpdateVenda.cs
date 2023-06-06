using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteAPI.Models.Domain;

namespace TesteAPI.Models.ViewModel
{
    public class UpdateVenda
    {
        [Key]
        [Required]
        public int? IdVenda { get; set; }

        [Required]
        public int? IdCliente { get; set; }

        [Required]
        public int? IdProduto { get; set; }

        [Required]
        public int QtdVenda { get; set; }

    }
}
