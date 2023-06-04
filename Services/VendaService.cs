using DealerMVC.Repositories.Interfaces;
using DealerMVC.Services.Interfaces;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Venda Create(CreateVenda createVenda)
        {
            var venda = new Venda
            {
                IdCliente = createVenda.IdCliente,
                IdProduto = createVenda.IdProduto,
                QtdVenda = createVenda.QtdVenda,
                VlrUnitarioVenda = createVenda.VlrUnitarioVenda,
                DthVenda = DateTime.Now
            };

            return _vendaRepository.Create(venda);
        }

        public Venda Delete(int id)
        {
            if(id<=0)
            {
                throw new Exception("O ID deve ser maior que zero!");
            }
            return _vendaRepository.Delete(id);
        }

        public IList<Venda> List()
        {
            var vendas = _vendaRepository.List();

            return vendas;
        }

        public Venda ListById(int id)
        {
            var venda = new Venda { IdVenda = id };

            return _vendaRepository.ListById(venda);
        }

        public IList<Cliente> ListByName(ListByNameCliente listCliente)
        {
            throw new NotImplementedException();
        }

        public Venda Update(UpdateVenda updateVenda)
        {
            var venda = new Venda
            {
                IdVenda = updateVenda.IdVenda,
                IdCliente = updateVenda.IdCliente,
                IdProduto = updateVenda.IdProduto,
                QtdVenda = updateVenda.QtdVenda,
                VlrUnitarioVenda = updateVenda.VlrUnitarioVenda,
                DthVenda = DateTime.Now
            };

            return _vendaRepository.Update(venda);
        }
    }
}
