using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Cliente.Modelo
{
    public class ClienteBanco : Persona
    {
        [Key]
        public string ClienteId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Contrasenia { get; set; }

        [Required]
        public bool Estado { get; set; }

    }
}
