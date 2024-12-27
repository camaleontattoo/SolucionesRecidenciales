using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class Rol : BaseEntity
    {
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del rol no puede exceder 50 caracteres")]
        public string NombreRol { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
