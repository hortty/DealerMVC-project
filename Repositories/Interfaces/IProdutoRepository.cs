using TesteAPI.Models.Domain;

namespace DealerMVC.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        public Produto Create(Produto produto);

        public Produto Delete(int id);

        public IList<Produto> List();

        public Produto Update(Produto produto);

        public IList<Produto> ListByDesc(Produto produto);

        public Produto ListById(Produto produto);
    }
}
