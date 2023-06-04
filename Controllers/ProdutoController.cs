using Microsoft.AspNetCore.Mvc;
using TesteAPI.Context;
using TesteAPI.Models.ViewModel;
using TesteAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using DealerMVC.Services.Interfaces;

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
            try
            {
                produtos = _produtoService.List();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new Exception(e.Message);
            }

            return View(produtos);
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


            return RedirectToAction("Listar", "Produto");
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

            return RedirectToAction("Listar", "Produto");
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

    }
}
