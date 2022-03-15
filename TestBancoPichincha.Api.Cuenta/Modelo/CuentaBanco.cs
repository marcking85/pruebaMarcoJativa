using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Cuenta.Modelo
{
    public class CuentaBanco
    {
        [Key]
        public string CuentaId { get; set; }

        [Required]
        [MaxLength(10)]
        public string NumeroCuenta { get; set; }

        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; }

        [Required]
        public double SaldoInicial { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public Guid? ClienteId { get; set; }
    }
}
