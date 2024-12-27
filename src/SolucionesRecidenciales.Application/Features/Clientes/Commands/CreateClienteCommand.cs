using MediatR;
using SolucionesRecidenciales.Application.Interfaces;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Application.Features.Clientes.Commands
{
    public class CreateClienteCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public CreateClienteCommandHandler(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                NIT = request.NIT,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Email = request.Email
            };

            await _clienteRepository.AddAsync(cliente);
            return cliente.Id;
        }
    }
}
