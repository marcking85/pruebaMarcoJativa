using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestBancoPichincha.Api.Cuenta.Aplicacion;
using TestBancoPichincha.Api.Cuenta.InterfaceRemota;
using TestBancoPichincha.Api.Cuenta.Modelo;
using TestBancoPichincha.Api.Cuenta.Persistencia;
using Xunit;

namespace TestBancoPichincha.Api.Test
{
    public class CuentasServiceTest
    {
        private IEnumerable<CuentaBanco> ObtenerDatosPrueba()
        {
            A.Configure<CuentaBanco>()
                .Fill(x => x.NumeroCuenta).AsArticleTitle()
                .Fill(x => x.Tipo).AsArticleTitle()
                .Fill(x => x.SaldoInicial)
                .Fill(x => x.Estado);

            var lista = A.ListOf<CuentaBanco>(10);
            lista[0].CuentaId = string.Empty;

            return lista;
        }

        private Mock<ContextoCuenta> CrearContexto()
        {
            var datosPrueba = ObtenerDatosPrueba().AsQueryable();

            var dbSet = new Mock<DbSet<CuentaBanco>>();
            dbSet.As<IQueryable<CuentaBanco>>().Setup(x => x.Provider).Returns(datosPrueba.Provider);
            dbSet.As<IQueryable<CuentaBanco>>().Setup(x => x.Expression).Returns(datosPrueba.Expression);
            dbSet.As<IQueryable<CuentaBanco>>().Setup(x => x.ElementType).Returns(datosPrueba.ElementType);
            dbSet.As<IQueryable<CuentaBanco>>().Setup(x => x.GetEnumerator()).Returns(datosPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<CuentaBanco>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<CuentaBanco>(datosPrueba.GetEnumerator()));

            var contexto = new Mock<ContextoCuenta>();
            contexto.Setup(x => x.Cuentas).Returns(dbSet.Object);
            return contexto;
        }

        [Fact]
        public async void GetCuentas()
        {
            System.Diagnostics.Debugger.Launch();
            var mockContexto = CrearContexto();
            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();
            var mockServices = new Mock<IClientesService>();

            Consulta.Manejador manejador = new Consulta.Manejador(mockContexto.Object, mapper, mockServices.Object);
            Consulta.Ejecuta request = new Consulta.Ejecuta();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());
        }
    }
}
