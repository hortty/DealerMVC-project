using Microsoft.AspNetCore.Mvc;
using TesteAPI.Context;
using TesteAPI.Models.ViewModel;
using TesteAPI.Models.Domain;

namespace TesteAPI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DataContext _dbContext;
        public ClienteController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {

            var clientes = _dbContext.Clientes.ToList();

            return View(clientes);
        }

        [HttpPost]
        [ActionName("Criar")]
        public IActionResult CreateCliente(CreateCliente createCliente)
        {
            var cliente = new Cliente
            {
                NmCliente = createCliente.NmCliente,
                Cidade = createCliente.Cidade
            };

            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();


            return View("Criar");
        }
    }
}
