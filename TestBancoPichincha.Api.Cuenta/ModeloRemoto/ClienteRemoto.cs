using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Cuenta.ModeloRemoto
{
    public class ClienteRemoto : PersonaRemoto
    {
        public Guid? ClienteId { get; set; }

        public string Contrasenia { get; set; }

        public bool Estado { get; set; }
    }
}
