using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.Modelo;
using TestBancoPichincha.Api.Cuenta.Persistencia;

namespace TestBancoPichincha.Api.Cuenta.Aplicacion
{
    public class ConsultaFiltro
    {
        public class CuentaUnico : IRequest<CuentaDto>
        {
            public string CuentaId { get; set; }
        }

        public class Manejador : IRequestHandler<CuentaUnico, CuentaDto>
        {
            public readonly ContextoCuenta _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoCuenta contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<CuentaDto> Handle(CuentaUnico request, CancellationToken cancellationToken)
            {
                var cuenta = await _contexto.Cuentas.Where(X => X.CuentaId == request.CuentaId).FirstOrDefaultAsync();
                if (cuenta == null)
                {
                    throw new Exception("No se encontró la cuenta.");
                }

                var cuentaDto = _mapper.Map<CuentaBanco, CuentaDto>(cuenta);
                return cuentaDto;
            }
        }
    }
}
