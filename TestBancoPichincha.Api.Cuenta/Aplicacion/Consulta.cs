using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.InterfaceRemota;
using TestBancoPichincha.Api.Cuenta.Modelo;
using TestBancoPichincha.Api.Cuenta.Persistencia;

namespace TestBancoPichincha.Api.Cuenta.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<CuentaDto>> { 
            public Ejecuta() { }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<CuentaDto>>
        {
            private readonly ContextoCuenta _contexto;
            private readonly IMapper _mapper;
            private readonly IClientesService _clientesService;

            public Manejador(ContextoCuenta contexto, IMapper mapper, IClientesService clientesService)
            {
                _contexto = contexto;
                _mapper = mapper;
                _clientesService = clientesService;
            }

            public async Task<List<CuentaDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var cuentas = await _contexto.Cuentas.ToListAsync();
                var listaCuentas = new List<CuentaDto>();
                foreach (var itemCuenta in cuentas)
                {
                    var cuenta = await _contexto.Cuentas.FirstOrDefaultAsync(x => x.CuentaId == itemCuenta.CuentaId);
                    var response = await _clientesService.GetCliente(cuenta.ClienteId);
                    if (response.resultado)
                    {
                        var objetoCliente = response.Cliente;
                        var cuentaDto = new CuentaDto
                        {
                            NumeroCuenta = cuenta.NumeroCuenta,
                            Tipo = cuenta.Tipo,
                            SaldoInicial = cuenta.SaldoInicial,
                            NombreCliente = objetoCliente.Nombre
                        };
                        listaCuentas.Add(cuentaDto);
                    }
                }
                return listaCuentas;
            }
        }
    }
}
