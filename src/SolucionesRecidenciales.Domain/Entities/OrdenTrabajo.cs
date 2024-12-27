using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class OrdenTrabajo : BaseEntity
    {
        [Required(ErrorMessage = "El edificio es obligatorio")]
        public int EdificioId { get; set; }
        public Edificio Edificio { get; set; }

        [Required(ErrorMessage = "El tipo de servicio es obligatorio")]
        [StringLength(100, ErrorMessage = "El tipo de servicio no puede exceder 100 caracteres")]
        public string TipoServicio { get; set; }

        [Required(ErrorMessage = "La fecha de solicitud es obligatoria")]
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;

        public DateTime? FechaProgramada { get; set; }
        public DateTime? FechaEjecucion { get; set; }

        [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres")]
        public string Estado { get; set; } = "Pendiente";

        [Range(1, 5, ErrorMessage = "La prioridad debe estar entre 1 y 5")]
        public int? PrioridadServicio { get; set; }
        
        public int? EmpleadoPrincipalId { get; set; }
        public Empleado EmpleadoPrincipal { get; set; }

        [StringLength(200, ErrorMessage = "Los empleados adicionales no pueden exceder 200 caracteres")]
        public string EmpleadosAdicionales { get; set; } // JSON con IDs de empleados
        
        [StringLength(500, ErrorMessage = "Los materiales utilizados no pueden exceder 500 caracteres")]
        public string MaterialesUtilizados { get; set; } // JSON con materiales y cantidades
        
        [Range(0, 1000, ErrorMessage = "El tiempo estimado debe estar entre 0 y 1000 horas")]
        public decimal? TiempoEstimado { get; set; } // Horas
        
        [Range(0, 1000, ErrorMessage = "El tiempo real debe estar entre 0 y 1000 horas")]
        public decimal? TiempoReal { get; set; }     // Horas
        
        [Range(0, double.MaxValue, ErrorMessage = "El costo de materiales debe ser un valor no negativo")]
        public decimal CostoMateriales { get; set; }
        
        [Range(0, double.MaxValue, ErrorMessage = "El costo de mano de obra debe ser un valor no negativo")]
        public decimal CostoManoObra { get; set; }
        
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string Observaciones { get; set; }
    }
}
