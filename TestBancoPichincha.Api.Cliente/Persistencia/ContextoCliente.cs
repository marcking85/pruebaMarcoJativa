using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cliente.Modelo;

namespace TestBancoPichincha.Api.Cliente.Persistencia
{
    public class ContextoCliente : DbContext
    {
        public ContextoCliente(DbContextOptions<ContextoCliente> options) : base(options) { }
        public DbSet<ClienteBanco> Clientes { get; set; }
    }
}
