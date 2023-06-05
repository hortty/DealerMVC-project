using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteAPI.Models.Domain;

namespace TesteAPI.Models.ViewModel
{
    public class CreateVenda
    {

        [ForeignKey("Cliente")]
        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("Produto")]
        [Required]
        public int IdProduto { get; set; }

        [Required]
        public int QtdVenda { get; set; }

    }
}
