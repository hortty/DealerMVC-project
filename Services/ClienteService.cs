using DealerMVC.Repositories.Interfaces;
using DealerMVC.Services.Interfaces;
using TesteAPI.Models.Domain;
using TesteAPI.Models.ViewModel;

namespace DealerMVC.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Create(CreateCliente createCliente)
        {
            var cliente = new Cliente
            {
                NmCliente = createCliente.NmCliente,
                Cidade = createCliente.Cidade
            };

            return _clienteRepository.Create(cliente);
        }

        public Cliente Delete(int id)
        {
            if(id<=0)
            {
                throw new Exception("O ID deve ser maior que zero!");
            }
            return _clienteRepository.Delete(id);
        }

        public IList<Cliente> List()
        {
            var clientes = _clienteRepository.List();

            return clientes;
        }

        public Cliente ListById(int id)
        {
            var cliente = new Cliente { IdCliente = id };

            return _clienteRepository.ListById(cliente);
        }

        public IList<Cliente> ListByName(ListByNameCliente listCliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(UpdateCliente updateCliente)
        {
            var cliente = new Cliente
            {
                IdCliente = updateCliente.IdCliente,
                NmCliente = updateCliente.NmCliente,
                Cidade = updateCliente.Cidade
            };

            return _clienteRepository.Update(cliente);
        }
    }
}
