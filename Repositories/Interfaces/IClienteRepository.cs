﻿using TesteAPI.Models.Domain;

namespace DealerMVC.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public Cliente Create(Cliente cliente);

        public Cliente Delete(Cliente cliente);

        public IList<Cliente> List();

        public Cliente Update(Cliente cliente);

        public IList<Cliente> ListByName(Cliente cliente);
    }
}