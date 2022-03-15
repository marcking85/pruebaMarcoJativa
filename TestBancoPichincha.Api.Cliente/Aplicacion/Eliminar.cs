using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cliente.Modelo;
using TestBancoPichincha.Api.Cliente.Persistencia;

namespace TestBancoPichincha.Api.Cliente.Aplicacion
{
    public class Eliminar
    {
        public class ClienteUnico : IRequest<ClienteDto>
        {
            public string ClienteId { get; set; }
        }

        public class Manejador : IRequestHandler<ClienteUnico, ClienteDto>
        {
            public readonly ContextoCliente _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoCliente contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<ClienteDto> Handle(ClienteUnico request, CancellationToken cancellationToken)
            {
                var cliente = await _contexto.Clientes.Where(X => X.ClienteId == request.ClienteId).FirstOrDefaultAsync();
                if (cliente == null)
                {
                    throw new Exception("No se encontró el cliente.");
                }

                _contexto.Clientes.Remove(cliente);
                var valor = await _contexto.SaveChangesAsync();
                return null;
            }
        }
    }
}
