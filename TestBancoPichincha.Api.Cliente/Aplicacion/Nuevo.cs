using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cliente.Modelo;
using TestBancoPichincha.Api.Cliente.Persistencia;

namespace TestBancoPichincha.Api.Cliente.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }

            public string Genero { get; set; }

            public int Edad { get; set; }

            public string Identificacion { get; set; }

            public string Direccion { get; set; }

            public string Telefono { get; set; }

            public string Contrasenia { get; set; }

            public bool Estado { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Genero).NotEmpty();
                RuleFor(x => x.Edad).NotEmpty();
                RuleFor(x => x.Identificacion).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.Contrasenia).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoCliente _contexto;
            public Manejador(ContextoCliente contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var clienteBanco = new ClienteBanco
                {
                    Nombre = request.Nombre,
                    Genero = request.Genero,
                    Edad = request.Edad,
                    Identificacion = request.Identificacion,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    Contrasenia = request.Contrasenia,
                    Estado = request.Estado,
                    ClienteId = Convert.ToString(Guid.NewGuid())
                };

                _contexto.Clientes.Add(clienteBanco);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el cliente.");
            }
        }
    }
}
