using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.InterfaceRemota;
using TestBancoPichincha.Api.Movimientos.Modelo;
using TestBancoPichincha.Api.Movimientos.Persistencia;

namespace TestBancoPichincha.Api.Movimientos.Aplicacion
{
    public class Consulta
    {
        public class ListaMovimientos : IRequest<List<MovimientoDto>> { }

        public class Manejador : IRequestHandler<ListaMovimientos, List<MovimientoDto>>
        {
            private readonly ContextoMovimiento _contexto;
            private readonly ICuentasService _cuentasService;

            public Manejador(ContextoMovimiento contexto, ICuentasService cuentasService)
            {
                _contexto = contexto;
                _cuentasService = cuentasService;
            }

            public async Task<List<MovimientoDto>> Handle(ListaMovimientos request, CancellationToken cancellationToken)
            {
                var movimientos = await _contexto.Movimientos.ToListAsync();
                var listaMovimientos = new List<MovimientoDto>();
                foreach (var itemMovimiento in movimientos)
                {
                    var movimiento = await _contexto.Movimientos.FirstOrDefaultAsync(x => x.MovimientoId == itemMovimiento.MovimientoId);
                    var response = await _cuentasService.GetCuenta(movimiento.CuentaId);
                    if (response.resultado)
                    {
                        var objetoCuenta = response.Cuenta;
                        var movimientoDto = new MovimientoDto
                        {
                            Fecha = movimiento.Fecha,
                            Tipo = movimiento.Tipo,
                            Valor = movimiento.Valor,
                            Saldo = movimiento.Saldo,
                            NumeroCuenta = objetoCuenta.NumeroCuenta,
                            NombreCliente = objetoCuenta.NombreCliente,
                            TipoCuenta = objetoCuenta.Tipo,
                            SaldoInicialCuenta = objetoCuenta.SaldoInicial
                        };
                        listaMovimientos.Add(movimientoDto);
                    }
                }
                return listaMovimientos;
            }
        }
    }
}
