using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models.ViewModel
{
    public class DeleteProduto
    {
        [Key]
        [Required]
        public int IdProduto { get; set; }
    }
}
