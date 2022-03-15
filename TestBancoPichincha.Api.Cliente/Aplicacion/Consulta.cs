using AutoMapper;
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
    public class Consulta
    {
        public class ListaCliente : IRequest<List<ClienteDto>> { }

        public class Manejador : IRequestHandler<ListaCliente, List<ClienteDto>>
        {
            private readonly ContextoCliente _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoCliente contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<ClienteDto>> Handle(ListaCliente request, CancellationToken cancellationToken)
            {
                var clientes = await _contexto.Clientes.ToListAsync();
                var clientesDto = _mapper.Map<List<ClienteBanco>, List<ClienteDto>>(clientes);

                return clientesDto;
            }
        }
    }
}
