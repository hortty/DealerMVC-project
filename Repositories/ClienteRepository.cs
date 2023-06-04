using DealerMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteAPI.Context;
using TesteAPI.Controllers;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _dbContext;
        public ClienteRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cliente Create(Cliente cliente)
        {

            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();

            return cliente;
        }

        public Cliente Delete(int id)
        {
            var clienteExistente = _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (clienteExistente == null)
            {
                throw new Exception("Cliente não existe");
            }

            _dbContext.Clientes.Remove(clienteExistente);
            _dbContext.SaveChanges();


            return clienteExistente;
        }

        public IList<Cliente> List()
        {
            var clientes = _dbContext.Clientes.ToList();

            return clientes;
        }

        public Cliente ListById(Cliente cliente)
        {
            var foundCliente = _dbContext.Clientes.FirstOrDefault(cl => cl.IdCliente == cliente.IdCliente);

            if(foundCliente == null)
            {
                throw new Exception("Cliente não encontrado!");
            }

            return foundCliente;
        }

        public IList<Cliente> ListByName(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(Cliente cliente)
        {

            var clienteExistente = _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);

            if (clienteExistente == null)
            {
                throw new Exception("Cliente não existe");
            }
            else
            {
                _dbContext.Clientes.Entry(clienteExistente).State = EntityState.Detached;
            }

            // Atualiza os dados do cliente existente com os novos dados
            clienteExistente.Cidade = cliente.Cidade;
            clienteExistente.NmCliente = cliente.NmCliente;

            _dbContext.Clientes.Entry(clienteExistente).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return clienteExistente;
        }
        
    }
}
