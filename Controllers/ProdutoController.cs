using Microsoft.AspNetCore.Mvc;
using TesteAPI.Context;
using TesteAPI.Models.ViewModel;
using TesteAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using DealerMVC.Services.Interfaces;
using DealerMVC.Services;

namespace TesteAPI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IList<Produto> produtos = new List<Produto>();
            ListProduto listaProduto = new ListProduto();
            listaProduto.Produtos = new List<Produto>();

            try
            {
                produtos = _produtoService.List();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new Exception(e.Message);
            }

            foreach (var produto in produtos)
            {
                listaProduto.Produtos.Add(produto);
            }


            return View(listaProduto);
        }

        [HttpPost]
        public IActionResult Criar(CreateProduto createProduto)
        {
            try
            {
                _produtoService.Create(createProduto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante o cadastro!");
            }


            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Produto produto = new Produto();

            try
            {
                produto = _produtoService.ListById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a edição!");
            }

            var updateProduto = new UpdateProduto
            {
                IdProduto = produto.IdProduto,
                DscProduto = produto.DscProduto,
                VlrUnitario = produto.VlrUnitario
            };

            return View(updateProduto);
        }

        [HttpPost]
        public IActionResult Editar(UpdateProduto Produto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _produtoService.Update(Produto);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //throw new Exception("Um erro aconteceu durante a edição dos dados!");
                }
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {

            try
            {
                _produtoService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a exclusão dos dados!");
            }

            return RedirectToAction("Listar", "Produto");
        }

        [HttpPost]
        public ActionResult PesquisarProduto(ListProduto listProdutoPesquisar)
        {
            ListProduto listaProduto = new ListProduto();
            listaProduto.Produtos = new List<Produto>();
            try
            {
                var pesquisarProduto = new Produto
                {
                    DscProduto = listProdutoPesquisar.DscProduto
                };

                var produtosEncontrados = _produtoService.ListByDesc(pesquisarProduto);

                foreach (var produto in produtosEncontrados)
                {
                    listaProduto.Produtos.Add(produto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(listaProduto);
        }

    }
}
