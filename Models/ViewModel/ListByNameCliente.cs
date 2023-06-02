using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class ListByNameCliente
    {

        [Required]
        public string NmCliente { get; set; } = String.Empty;

    }
}
