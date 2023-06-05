using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services.Interfaces
{
    public interface IVendaService
    {
        public Venda Create(CreateVenda createVenda);

        public Venda Delete(int id);

        public IList<Venda> List();

        public Venda Update(UpdateVenda updateVenda);

        public Venda ListById(int id);

        public List<Venda> ListByNameCliente(Cliente cliente);

        public IList<Venda> ListByDscProduto(Produto produto);
    }
}
