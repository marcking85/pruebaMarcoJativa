using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.Modelo;

namespace TestBancoPichincha.Api.Cuenta.Persistencia
{
    public class ContextoCuenta : DbContext
    {
        public ContextoCuenta() { }
        public ContextoCuenta(DbContextOptions<ContextoCuenta> options) : base(options) { }

        public virtual DbSet<CuentaBanco> Cuentas { get; set; }
    }
}
