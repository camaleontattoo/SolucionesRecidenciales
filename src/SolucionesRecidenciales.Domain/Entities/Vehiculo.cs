using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class Vehiculo : BaseEntity
    {
        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(20, ErrorMessage = "La placa no puede exceder 20 caracteres")]
        public string Placa { get; set; }

        [StringLength(100, ErrorMessage = "La marca no puede exceder 100 caracteres")]
        public string Marca { get; set; }

        [StringLength(100, ErrorMessage = "El modelo no puede exceder 100 caracteres")]
        public string Modelo { get; set; }

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Año { get; set; }

        [StringLength(50, ErrorMessage = "El tipo de vehículo no puede exceder 50 caracteres")]
        public string TipoVehiculo { get; set; } // Moto, Camioneta, Camión

        [StringLength(50, ErrorMessage = "El estado actual no puede exceder 50 caracteres")]
        public string EstadoActual { get; set; } = "Disponible";

        public DateTime? UltimoMantenimiento { get; set; }
        public DateTime? ProximoMantenimiento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El kilometraje debe ser un valor positivo")]
        public decimal KilometrajeActual { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo de mantenimiento debe ser un valor positivo")]
        public decimal CostoMantenimientoUltimo { get; set; }
    }
}
