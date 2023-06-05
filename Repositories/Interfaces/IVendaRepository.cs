using TesteAPI.Models.Domain;

namespace DealerMVC.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        public Venda Create(Venda venda);

        public Venda Delete(int id);

        public IList<Venda> List();

        public Venda Update(Venda venda);

        public List<Venda> ListByNameCliente(Cliente cliente);

        public IList<Venda> ListByDscProduto(Produto produto);

        public Venda ListById(Venda venda);
    }
}
