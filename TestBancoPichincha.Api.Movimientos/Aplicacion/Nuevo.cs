using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.Modelo;
using TestBancoPichincha.Api.Movimientos.Persistencia;

namespace TestBancoPichincha.Api.Movimientos.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Tipo { get; set; }

            public double Valor { get; set; }

            public double Saldo { get; set; }

            public Guid? CuentaId { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Tipo).NotEmpty();
                RuleFor(x => x.Valor).NotEmpty();
                RuleFor(x => x.Saldo).NotEmpty();
                RuleFor(x => x.CuentaId).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoMovimiento _contexto;
            public Manejador(ContextoMovimiento contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var movimiento = new Movimiento
                {
                    MovimientoId = Convert.ToString(Guid.NewGuid()),
                    Fecha = DateTime.Now,
                    Tipo = request.Tipo,
                    Valor = request.Valor,
                    Saldo = request.Saldo,
                    CuentaId = request.CuentaId
                };

                _contexto.Movimientos.Add(movimiento);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el movimiento.");
            }
        }
    }
}
