using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Movimientos.Aplicacion
{
    public class MovimientoDto
    {
        public DateTime? Fecha { get; set; }

        public string Tipo { get; set; }

        public double Valor { get; set; }

        public double Saldo { get; set; }

        public double TotalRetirado { get; set; }

        public string NombreCliente { get; set; }

        public string NumeroCuenta { get; set; }

        public string TipoCuenta { get; set; }

        public double SaldoInicialCuenta { get; set; }
    }
}
