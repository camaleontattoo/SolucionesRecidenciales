using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Roles");

            // Configuración de la clave primaria
            builder.HasKey(r => r.Id);

            // Configuración de propiedades
            builder.Property(r => r.NombreRol)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Descripcion)
                .HasMaxLength(200);

            // Índices
            builder.HasIndex(r => r.NombreRol).IsUnique();

            // Relaciones
            builder.HasMany(r => r.Empleados)
                .WithOne(e => e.Rol)
                .HasForeignKey(e => e.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
