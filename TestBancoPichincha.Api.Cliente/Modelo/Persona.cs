using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Cliente.Modelo
{
    public class Persona
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(1)]
        public string Genero { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [MaxLength(13)]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(12)]
        public string Telefono { get; set; }
    }
}
