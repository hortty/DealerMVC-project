using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAPI.Models.Domain
{
    public class Venda
    {
        [Key]
        [Required]
        public int IdVenda { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Produto")]
        [Required]
        public int IdProduto { get; set; }

        public Produto Produto { get; set; }

        [Required]
        public int QtdVenda { get; set; }

        [Required]
        public float VlrUnitarioVenda { get; set; }

        public DateTime DthVenda { get; set; }

        public float VlrTotalVenda
        {
            get { return QtdVenda * VlrUnitarioVenda; }
        }

    }
}
