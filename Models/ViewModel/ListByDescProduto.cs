using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class ListByDescProduto
    {

        [Required]
        public string DscProduto { get; set; } = String.Empty;

    }
}
