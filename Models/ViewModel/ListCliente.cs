using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteAPI.Models.Domain;

namespace TesteAPI.Models.ViewModel
{
    public class ListCliente
    {
        public List<Cliente> Clientes { get; set; }

        public string NmCliente { get; set; }

    }
}
