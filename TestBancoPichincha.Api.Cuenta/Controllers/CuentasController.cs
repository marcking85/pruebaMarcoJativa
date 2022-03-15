using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.Aplicacion;

namespace TestBancoPichincha.Api.Cuenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<CuentaDto>>> GetCuentas()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaDto>> GetCuenta(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.CuentaUnico { CuentaId = id });
        }
    }
}
