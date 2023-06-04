﻿using DealerMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteAPI.Context;
using TesteAPI.Controllers;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _dbContext;
        public VendaRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Venda Create(Venda venda)
        {

            _dbContext.Vendas.Add(venda);
            _dbContext.SaveChanges();

            return venda;
        }

        public Venda Delete(int id)
        {
            var vendaExistente = _dbContext.Vendas.FirstOrDefault(c => c.IdVenda == id);

            if (vendaExistente == null)
            {
                throw new Exception("Essa venda não foi encontrada");
            }

            _dbContext.Vendas.Remove(vendaExistente);
            _dbContext.SaveChanges();

            return vendaExistente;
        }

        public IList<Venda> List()
        {
            var vendas = _dbContext.Vendas
                .Include(cl => cl.Cliente)
                .Include(pr => pr.Produto)
                .ToList();

            return vendas;
        }

        public Venda ListById(Venda venda)
        {
            var foundVenda = _dbContext.Vendas.FirstOrDefault(cl => cl.IdVenda == venda.IdVenda);

            if(foundVenda == null)
            {
                throw new Exception("Venda não encontrado!");
            }

            return foundVenda;
        }

        public IList<Venda> ListByName(Venda venda)
        {
            throw new NotImplementedException();
        }

        public Venda Update(Venda venda)
        {

            var vendaExistente = _dbContext.Vendas.FirstOrDefault(c => c.IdVenda == venda.IdVenda);

            if (vendaExistente == null)
            {
                throw new Exception("Essa venda não foi encontrada");
            }
            else
            {
                _dbContext.Vendas.Entry(vendaExistente).State = EntityState.Detached;
            }

            // Atualiza os dados do venda existente com os novos dados
            vendaExistente.IdCliente = venda.IdCliente;
            vendaExistente.IdProduto = venda.IdProduto;
            vendaExistente.QtdVenda = venda.QtdVenda;
            vendaExistente.VlrUnitarioVenda = venda.VlrUnitarioVenda;

            _dbContext.Vendas.Entry(vendaExistente).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return vendaExistente;
        }
        
    }
}
