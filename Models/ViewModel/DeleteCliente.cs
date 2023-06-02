using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class DeleteCliente
    {
        [Key]
        [Required]
        public int IdCliente { get; set; }
    }
}
