using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services.Interfaces
{
    public interface IClienteService
    {
        public Cliente Create(CreateCliente createCliente);

        public Cliente Delete(DeleteCliente deleteCliente);

        public IList<Cliente> List();

        public Cliente Update(UpdateCliente updateCliente);

        public IList<Cliente> ListByName(ListByNameCliente listCliente); 
    }
}
