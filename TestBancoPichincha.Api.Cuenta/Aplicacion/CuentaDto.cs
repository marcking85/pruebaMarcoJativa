using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Cuenta.Aplicacion
{
    public class CuentaDto
    {
        public string NumeroCuenta { get; set; }

        public string Tipo { get; set; }

        public double SaldoInicial { get; set; }

        public string NombreCliente { get; set; }

    }
}
