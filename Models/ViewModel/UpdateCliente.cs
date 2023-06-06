using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class UpdateCliente
    {
        [Key]
        [Required]
        public int? IdCliente { get; set; }

        [Required]
        public string NmCliente { get; set; } = String.Empty;

        [Required]
        public string Cidade { get; set; } = String.Empty;
    }
}
