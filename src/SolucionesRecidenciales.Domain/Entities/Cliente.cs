using SolucionesRecidenciales.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SolucionesRecidenciales.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El NIT es obligatorio")]
        [StringLength(20, ErrorMessage = "El NIT no puede exceder 20 caracteres")]
        public string NIT { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; }

        [Phone(ErrorMessage = "El teléfono no es válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder 100 caracteres")]
        public string Email { get; set; }

        public ICollection<Edificio> Edificios { get; set; } = new List<Edificio>();
        public ICollection<Cotizacion> Cotizaciones { get; set; } = new List<Cotizacion>();
    }
}
