using Microsoft.AspNetCore.Mvc;
using TesteAPI.Context;
using TesteAPI.Models.ViewModel;
using TesteAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using DealerMVC.Services.Interfaces;

namespace TesteAPI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IList<Cliente> clientes = new List<Cliente>();
            try
            {
                clientes = _clienteService.List();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new Exception(e.Message);
            }

            return View(clientes);
        }

        [HttpPost]
        public IActionResult Criar(CreateCliente createCliente)
        {
            try
            {
                _clienteService.Create(createCliente);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante o cadastro!");
            }


            return RedirectToAction("Listar", "Cliente");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Cliente cliente = new Cliente();

            try
            {
                cliente = _clienteService.ListById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a edição!");
            }

            var updateCliente = new UpdateCliente
            {
                IdCliente = cliente.IdCliente,
                NmCliente = cliente.NmCliente,
                Cidade = cliente.Cidade
            };

            return View(updateCliente);
        }

        [HttpPost]
        public IActionResult Editar(UpdateCliente cliente)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _clienteService.Update(cliente);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //throw new Exception("Um erro aconteceu durante a edição dos dados!");
                }
            }

            return RedirectToAction("Listar", "Cliente");
        }

        public IActionResult Excluir(int id)
        {

            try
            {
                _clienteService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a exclusão dos dados!");
            }

            return RedirectToAction("Listar", "Cliente");
        }

    }
}
