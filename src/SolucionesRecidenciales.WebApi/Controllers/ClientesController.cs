using Microsoft.AspNetCore.Mvc;
using MediatR;
using SolucionesRecidenciales.Application.Features.Clientes.Commands;
using SolucionesRecidenciales.Application.Features.Clientes.Queries;
using SolucionesRecidenciales.Domain.Entities;
using SolucionesRecidenciales.Application.Interfaces;

namespace SolucionesRecidenciales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCliente([FromBody] CreateClienteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateCliente(int id, [FromBody] UpdateClienteCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCliente(int id)
        {
            var command = new DeleteClienteCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllClientes()
        {
            var query = new GetAllClientesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var query = new GetClienteByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
