using Microsoft.AspNetCore.Mvc;
using TesteAPI.Context;
using TesteAPI.Models.ViewModel;
using TesteAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using DealerMVC.Services.Interfaces;

namespace TesteAPI.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IList<Venda> vendas = new List<Venda>();
            try
            {
                vendas = _vendaService.List();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new Exception(e.Message);
            }

            return View(vendas);
        }

        [HttpPost]
        public IActionResult Criar(CreateVenda createVenda)
        {
            try
            {
                _vendaService.Create(createVenda);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante o cadastro!");
            }


            return RedirectToAction("Listar", "Venda");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Venda venda = new Venda();

            try
            {
                venda = _vendaService.ListById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a edição!");
            }

            var updateVenda = new UpdateVenda
            {
                IdVenda = venda.IdVenda,
                IdCliente = venda.IdCliente,
                IdProduto = venda.IdProduto,
                QtdVenda = venda.QtdVenda,
                VlrUnitarioVenda = venda.VlrUnitarioVenda,
            };

            return View(updateVenda);
        }

        [HttpPost]
        public IActionResult Editar(UpdateVenda Venda)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _vendaService.Update(Venda);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //throw new Exception("Um erro aconteceu durante a edição dos dados!");
                }
            }

            return RedirectToAction("Listar", "Venda");
        }

        public IActionResult Excluir(int id)
        {

            try
            {
                _vendaService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a exclusão dos dados!");
            }

            return RedirectToAction("Listar", "Venda");
        }

    }
}
