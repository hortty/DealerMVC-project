using DealerMVC.Repositories.Interfaces;
using DealerMVC.Services.Interfaces;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Create(CreateProduto createProduto)
        {
            var produto = new Produto
            {
                DscProduto = createProduto.DscProduto,
                VlrUnitario = createProduto.VlrUnitario
            };

            return _produtoRepository.Create(produto);
        }

        public Produto Delete(int id)
        {
            if(id<=0)
            {
                throw new Exception("O ID deve ser maior que zero!");
            }
            return _produtoRepository.Delete(id);
        }

        public IList<Produto> List()
        {
            var produtos = _produtoRepository.List();

            return produtos;
        }

        public Produto ListById(int id)
        {
            var produto = new Produto { IdProduto = id };

            return _produtoRepository.ListById(produto);
        }

        public IList<Produto> ListByDesc(Produto produto)
        {
            var produtos = _produtoRepository.ListByDesc(produto);

            return produtos;
        }

        public Produto Update(UpdateProduto updateProduto)
        {
            var produto = new Produto
            {
                IdProduto = updateProduto.IdProduto,
                DscProduto = updateProduto.DscProduto,
                VlrUnitario = updateProduto.VlrUnitario
            };

            return _produtoRepository.Update(produto);
        }
    }
}
