using Microsoft.AspNetCore.Mvc;
using TesteAPI.Context;
using TesteAPI.Models.ViewModel;
using TesteAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using DealerMVC.Services.Interfaces;
using DealerMVC.Services;

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
            ListCliente listaCliente = new ListCliente();
            listaCliente.Clientes = new List<Cliente>();

            try
            {
                clientes = _clienteService.List();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new Exception(e.Message);
            }

            foreach(var cliente in clientes)
            {
                listaCliente.Clientes.Add(cliente);
            }

            return View(listaCliente);
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


            return View();
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

        [HttpPut]
        public IActionResult Editar(UpdateCliente updateCliente)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _clienteService.Update(updateCliente);
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
                _clienteService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw new Exception("Um erro aconteceu durante a exclusão dos dados!");
            }

            return RedirectToAction("Listar", "Cliente");
        }

        [HttpPost]
        public ActionResult PesquisarCliente(ListCliente clientes)
        {
            ListCliente listaCliente = new ListCliente();
            listaCliente.Clientes = new List<Cliente>();

            try
            {
                var pesquisarCliente = new Cliente
                {
                    NmCliente = clientes.NmCliente
                };

                var foundClientes = _clienteService.ListByName(pesquisarCliente);

                foreach (var cliente in foundClientes)
                {
                    listaCliente.Clientes.Add(cliente);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(listaCliente);
        }

    }
}
