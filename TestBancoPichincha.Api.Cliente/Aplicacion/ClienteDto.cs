﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Cliente.Aplicacion
{
    public class ClienteDto
    {
        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int Edad { get; set; }

        public string Identificacion { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
    }
}