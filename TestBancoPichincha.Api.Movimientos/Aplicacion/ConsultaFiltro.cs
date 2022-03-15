using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.Modelo;
using TestBancoPichincha.Api.Movimientos.Persistencia;

namespace TestBancoPichincha.Api.Movimientos.Aplicacion
{
    public class ConsultaFiltro
    {
        public class MovimientoUnico : IRequest<MovimientoDto>
        {
            public string MovimientoId { get; set; }
        }

        public class Manejador : IRequestHandler<MovimientoUnico, MovimientoDto>
        {
            public readonly ContextoMovimiento _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoMovimiento contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<MovimientoDto> Handle(MovimientoUnico request, CancellationToken cancellationToken)
            {
                var movimiento = await _contexto.Movimientos.Where(X => X.MovimientoId == request.MovimientoId).FirstOrDefaultAsync();
                if (movimiento == null)
                {
                    throw new Exception("No se encontró el movimiento.");
                }

                var movimientoDto = _mapper.Map<Movimiento, MovimientoDto>(movimiento);
                return movimientoDto;
            }
        }
    }
}
