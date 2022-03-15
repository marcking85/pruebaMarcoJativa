using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.Aplicacion;

namespace TestBancoPichincha.Api.Movimientos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMediator _mediator;
        const double LIMITERETIRODIARIO = 1000;

        public MovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            if (data.Tipo.Equals("RETIRO"))
            {
                if(data.Saldo == 0)
                {
                    throw new Exception("Saldo no disponible.");
                }
                else if(data.Saldo > 0 && data.Saldo >= data.Valor)
                {
                    data.Saldo = Math.Round((data.Saldo - data.Valor), 2);
                }
            }
            else if(data.Tipo.Equals("DEPOSITO"))
            {
                data.Saldo = Math.Round((data.Saldo + data.Valor), 2);
            }
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<MovimientoDto>>> GetMovimientos()
        {
            return await _mediator.Send(new Consulta.ListaMovimientos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoDto>> GetMovimiento(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.MovimientoUnico { MovimientoId = id });
        }

        [HttpGet("{id}/{fechaInicial}/{fechaFinal}")]
        public async Task<ActionResult<List<MovimientoDto>>> GetMovimientos(string id, DateTime fechaInicial, DateTime fechaFinal)
        {
            return await _mediator.Send(new ConsultaMovimientos.ListaMovimientos());
        }
    }
}
