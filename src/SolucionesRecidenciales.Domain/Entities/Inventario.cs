using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class Inventario : BaseEntity
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor no negativo")]
        public int Cantidad { get; set; }

        [StringLength(20, ErrorMessage = "La unidad de medida no puede exceder 20 caracteres")]
        public string UnidadMedida { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio unitario debe ser un valor no negativo")]
        public decimal PrecioUnitario { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo debe ser un valor no negativo")]
        public int StockMinimo { get; set; }

        [StringLength(100, ErrorMessage = "La ubicación de bodega no puede exceder 100 caracteres")]
        public string UbicacionBodega { get; set; }

        public DateTime? FechaUltimaEntrada { get; set; }
        public DateTime? FechaUltimaSalida { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo unitario debe ser un valor no negativo")]
        public decimal CostoUnitario { get; set; }
    }
}
