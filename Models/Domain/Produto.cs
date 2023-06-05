using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.Domain
{
    public class Produto
    {
        [Key]
        [Required]
        public int? IdProduto { get; set; }

        [Required]
        public string DscProduto { get; set; } = String.Empty;

        [Required]
        public float VlrUnitario { get; set; }
    }
}
