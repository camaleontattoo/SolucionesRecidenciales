using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class Empleado : BaseEntity
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        [Phone(ErrorMessage = "El teléfono no es válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder 100 caracteres")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "La especialidad no puede exceder 100 caracteres")]
        public string Especialidad { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [StringLength(20, ErrorMessage = "El número de identificación no puede exceder 20 caracteres")]
        public string NumeroIdentificacion { get; set; }

        public DateTime? FechaIngreso { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo")]
        public decimal Salario { get; set; }

        [StringLength(50, ErrorMessage = "El estado laboral no puede exceder 50 caracteres")]
        public string EstadoLaboral { get; set; } = "Activo";

        public ICollection<OrdenTrabajo> OrdenesTrabajo { get; set; } = new List<OrdenTrabajo>();
    }
}
