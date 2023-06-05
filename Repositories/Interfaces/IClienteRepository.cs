using TesteAPI.Models.Domain;

namespace DealerMVC.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public Cliente Create(Cliente cliente);

        public Cliente Delete(int id);

        public IList<Cliente> List();

        public Cliente Update(Cliente cliente);

        public List<Cliente> ListByName(Cliente cliente);

        public Cliente ListById(Cliente cliente);
    }
}
