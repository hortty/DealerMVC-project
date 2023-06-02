using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services.Interfaces
{
    public interface IProdutoService
    {
        public Produto Create(CreateProduto createProduto);

        public Produto Delete(DeleteProduto deleteProduto);

        public IList<Produto> List();

        public Produto Update(UpdateProduto updateProduto);

        public IList<Produto> ListByDesc(ListByDescProduto listProduto); 
    }
}
