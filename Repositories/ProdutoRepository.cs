using DealerMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteAPI.Context;
using TesteAPI.Controllers;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _dbContext;
        public ProdutoRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Produto Create(Produto produto)
        {

            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();

            return produto;
        }

        public Produto Delete(int id)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(c => c.IdProduto == id);

            if (produtoExistente == null)
            {
                throw new Exception("Esse produto não existe");
            }

            _dbContext.Produtos.Remove(produtoExistente);
            _dbContext.SaveChanges();

            return produtoExistente;
        }

        public IList<Produto> List()
        {
            var produtos = _dbContext.Produtos.ToList();

            return produtos;
        }

        public Produto ListById(Produto produto)
        {
            var foundProduto = _dbContext.Produtos.FirstOrDefault(cl => cl.IdProduto == produto.IdProduto);

            if(foundProduto == null)
            {
                throw new Exception("Produto não encontrado!");
            }

            return foundProduto;
        }

        public IList<Produto> ListByDesc(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto Update(Produto produto)
        {

            var produtoExistente = _dbContext.Produtos.FirstOrDefault(c => c.IdProduto == produto.IdProduto);

            if (produtoExistente == null)
            {
                throw new Exception("Esse produto não existe");
            }
            else
            {
                _dbContext.Produtos.Entry(produtoExistente).State = EntityState.Detached;
            }

            produtoExistente.DscProduto = produto.DscProduto;
            produtoExistente.VlrUnitario = produto.VlrUnitario;

            _dbContext.Produtos.Entry(produtoExistente).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return produtoExistente;
        }
        
    }
}
