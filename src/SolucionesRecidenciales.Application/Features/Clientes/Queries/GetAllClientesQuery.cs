using MediatR;
using Microsoft.EntityFrameworkCore;
using SolucionesRecidenciales.Domain.Entities;
using SolucionesRecidenciales.Application.Interfaces;

namespace SolucionesRecidenciales.Application.Features.Clientes.Queries
{
    public class GetAllClientesQuery : IRequest<List<Cliente>>
    {
    }

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, List<Cliente>>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public GetAllClientesQueryHandler(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetAllAsync();
        }
    }
}
