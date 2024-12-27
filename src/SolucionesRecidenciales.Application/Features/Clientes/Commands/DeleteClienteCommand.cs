using MediatR;
using SolucionesRecidenciales.Domain.Entities;
using SolucionesRecidenciales.Application.Interfaces;

namespace SolucionesRecidenciales.Application.Features.Clientes.Commands
{
    public class DeleteClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, bool>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public DeleteClienteCommandHandler(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
                return false;

            await _clienteRepository.DeleteAsync(cliente);
            return true;
        }
    }
}
