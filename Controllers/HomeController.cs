using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml;
using TesteAPI.Context;
using TesteAPI.Models;
using TesteAPI.Models.Domain;

namespace TesteAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient httpClient;
        private readonly string url = "https://camposdealer.dev/Sites/TesteAPI/";
        private readonly DataContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DataContext dbContext)
        {
            _logger = logger;
            httpClient = new HttpClient();
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoadData()
        {
            try
            {
                var clientes = new List<Cliente>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();

                    var res = await client.GetAsync("cliente");

                    if (res.IsSuccessStatusCode)
                    {
                        var resposta = res.Content.ReadAsStringAsync().Result;

                        var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                        clientes = JsonConvert.DeserializeObject<List<Cliente>>(stringResponse);

                        clientes.ForEach(cliente => cliente.IdCliente = null);

                        if(clientes != null)
                        {
                            _dbContext.Clientes.AddRange(clientes);
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var produtos = new List<Produto>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();

                    var res = await client.GetAsync("produto");

                    if (res.IsSuccessStatusCode)
                    {
                        var resposta = res.Content.ReadAsStringAsync().Result;

                        var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                        produtos = JsonConvert.DeserializeObject<List<Produto>>(stringResponse);

                        produtos.ForEach(produto => produto.IdProduto = null);

                        if (produtos != null)
                        {
                            _dbContext.Produtos.AddRange(produtos);
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var vendas = new List<Venda>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();

                    var res = await client.GetAsync("venda");

                    if (res.IsSuccessStatusCode)
                    {
                        var resposta = res.Content.ReadAsStringAsync().Result;

                        var stringResponse = JsonConvert.DeserializeObject<string>(resposta);

                        vendas = JsonConvert.DeserializeObject<List<Venda>>(stringResponse);

                        vendas.ForEach(venda => venda.IdVenda = null);

                    if (vendas != null)
                        {
                            _dbContext.Vendas.AddRange(vendas);
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction("Listar", "Cliente");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}