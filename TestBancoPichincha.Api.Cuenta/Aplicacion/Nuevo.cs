using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.Modelo;
using TestBancoPichincha.Api.Cuenta.Persistencia;

namespace TestBancoPichincha.Api.Cuenta.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string NumeroCuenta { get; set; }

            public string Tipo { get; set; }

            public double SaldoInicial { get; set; }

            public bool Estado { get; set; }

            public Guid? ClienteId { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.NumeroCuenta).NotEmpty();
                RuleFor(x => x.Tipo).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.ClienteId).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoCuenta _contexto;
            public Manejador(ContextoCuenta contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var cuentaBanco = new CuentaBanco
                {
                    CuentaId = Convert.ToString(Guid.NewGuid()),
                    NumeroCuenta = request.NumeroCuenta,
                    Tipo = request.Tipo,
                    SaldoInicial = request.SaldoInicial,
                    Estado = request.Estado,
                };

                _contexto.Cuentas.Add(cuentaBanco);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar la cuenta.");
            }
        }
    }
}
