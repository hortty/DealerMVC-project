using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class CreateProduto
    {
        [Required]
        public string DscProduto { get; set; } = String.Empty;

        [Required]
        public float VlrUnitario { get; set; }
    }
}
