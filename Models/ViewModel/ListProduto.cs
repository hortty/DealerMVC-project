using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteAPI.Models.Domain;

namespace TesteAPI.Models.ViewModel
{
    public class ListProduto
    {
        public List<Produto> Produtos { get; set; }

        public string DscProduto { get; set; }
    }
}
