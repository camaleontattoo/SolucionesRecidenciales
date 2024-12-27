using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class Cotizacion : BaseEntity
    {
        [Required(ErrorMessage = "El edificio es obligatorio")]
        public int EdificioId { get; set; }
        public Edificio Edificio { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "El número de cotización es obligatorio")]
        [StringLength(50, ErrorMessage = "El número de cotización no puede exceder 50 caracteres")]
        public string NumeroCotizacion { get; set; }

        [Required(ErrorMessage = "La fecha de cotización es obligatoria")]
        public DateTime FechaCotizacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaVencimiento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto total debe ser un valor no negativo")]
        public decimal MontoTotal { get; set; }

        [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres")]
        public string Estado { get; set; } = "Pendiente";
        
        [StringLength(50, ErrorMessage = "El número de cuenta no puede exceder 50 caracteres")]
        public string NumeroCuenta { get; set; }

        [StringLength(100, ErrorMessage = "El banco no puede exceder 100 caracteres")]
        public string Banco { get; set; }

        [StringLength(50, ErrorMessage = "El tipo de cuenta no puede exceder 50 caracteres")]
        public string TipoCuenta { get; set; }
        
        [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
        public string Notas { get; set; }
    }
}
