using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteAPI.Models.Domain;

namespace TesteAPI.Models.ViewModel
{
    public class ListVenda
    {
        public List<Venda> Vendas { get; set; }

        public string NmCliente { get; set; }

        public string DscProduto { get; set; }
    }
}
