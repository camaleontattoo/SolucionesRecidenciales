using MediatR;
using SolucionesRecidenciales.Domain.Entities;
using SolucionesRecidenciales.Application.Interfaces;

namespace SolucionesRecidenciales.Application.Features.Clientes.Queries
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public int Id { get; set; }
    }

    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public GetClienteByIdQueryHandler(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetByIdAsync(request.Id);
        }
    }
}
