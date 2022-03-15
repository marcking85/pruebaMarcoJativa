using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cliente.Aplicacion;

namespace TestBancoPichincha.Api.Cliente.Controllers
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
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetClientes()
        {
            return await _mediator.Send(new Consulta.ListaCliente());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.ClienteUnico { ClienteId = id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            await _mediator.Send(new Eliminar.ClienteUnico { ClienteId = id });
            return null;
        }
    }
}
