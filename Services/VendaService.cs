using DealerMVC.Repositories.Interfaces;
using DealerMVC.Services.Interfaces;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoService _produtoService;

        public VendaService(IVendaRepository vendaRepository, IProdutoService produtoService)
        {
            _vendaRepository = vendaRepository;
            _produtoService = produtoService;
        }

        public Venda Create(CreateVenda createVenda)
        {

            var produto = _produtoService.ListById(createVenda.IdProduto);

            var venda = new Venda
            {
                IdCliente = createVenda.IdCliente,
                IdProduto = createVenda.IdProduto,
                QtdVenda = createVenda.QtdVenda,
                VlrUnitarioVenda = produto.VlrUnitario,
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
            var produto = _produtoService.ListById(updateVenda.IdProduto);

            var venda = new Venda
            {
                IdVenda = updateVenda.IdVenda,
                IdCliente = updateVenda.IdCliente,
                IdProduto = updateVenda.IdProduto,
                QtdVenda = updateVenda.QtdVenda,
                VlrUnitarioVenda = produto.VlrUnitario,
                DthVenda = DateTime.Now
            };

            return _vendaRepository.Update(venda);
        }

        public List<Venda> ListByNameCliente(Cliente cliente)
        {
            return _vendaRepository.ListByNameCliente(cliente);
        }

        public IList<Venda> ListByDscProduto(Produto produto)
        {
            return _vendaRepository.ListByDscProduto(produto);
        }

    }
}
