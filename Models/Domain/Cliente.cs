using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.Domain
{
    public class Cliente
    {
        [Key]
        public int? IdCliente { get; set; }

        [Required]
        public string NmCliente { get; set; } = String.Empty;

        [Required]
        public string Cidade { get; set; } = String.Empty;
    }
}
