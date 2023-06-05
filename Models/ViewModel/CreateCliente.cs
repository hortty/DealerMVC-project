using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class CreateCliente
    {
        [Required]
        public string nmCliente { get; set; } = String.Empty;

        [Required]
        public string Cidade { get; set; } = String.Empty;
    }
}
