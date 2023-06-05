using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.Domain
{
    public class Cliente
    {
        [Key]
        [Required]
        public int? idCliente { get; set; }

        [Required]
        public string nmCliente { get; set; } = String.Empty;

        [Required]
        public string Cidade { get; set; } = String.Empty;
    }
}
