using MediatR;
using SolucionesRecidenciales.Domain.Entities;
using SolucionesRecidenciales.Application.Interfaces;

namespace SolucionesRecidenciales.Application.Features.Clientes.Commands
{
    public class UpdateClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public UpdateClienteCommandHandler(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                return false;

            cliente.Nombre = request.Nombre;
            cliente.NIT = request.NIT;
            cliente.Direccion = request.Direccion;
            cliente.Telefono = request.Telefono;
            cliente.Email = request.Email;

            await _clienteRepository.UpdateAsync(cliente);
            return true;
        }
    }
}
