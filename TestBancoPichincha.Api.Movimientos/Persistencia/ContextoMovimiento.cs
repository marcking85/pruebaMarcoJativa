using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.Modelo;

namespace TestBancoPichincha.Api.Movimientos.Persistencia
{
    public class ContextoMovimiento : DbContext
    {
        public ContextoMovimiento(DbContextOptions<ContextoMovimiento> options) : base(options) { }

        public DbSet<Movimiento> Movimientos { get; set; }
    }
}
