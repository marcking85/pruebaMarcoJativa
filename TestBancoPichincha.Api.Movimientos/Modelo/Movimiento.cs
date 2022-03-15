using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestBancoPichincha.Api.Movimientos.Modelo
{
    public class Movimiento
    {
        [Key]
        public string MovimientoId { get; set; }

        [Required]
        [MaxLength(10)]
        public DateTime? Fecha { get; set; }

        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public double Saldo { get; set; }

        [Required]
        public Guid? CuentaId { get; set; }
    }
}
