using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class UpdateProduto
    {
        [Key]
        [Required]
        public int IdProduto { get; set; }

        [Required]
        public string DscProduto { get; set; } = String.Empty;

        [Required]
        public float VlrUnitario { get; set; }
    }
}
