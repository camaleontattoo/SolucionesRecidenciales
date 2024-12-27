using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Empleados");

            // Configuración de la clave primaria
            builder.HasKey(e => e.Id);

            // Configuración de propiedades
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Telefono)
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .HasMaxLength(100);

            builder.Property(e => e.Especialidad)
                .HasMaxLength(100);

            builder.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(20);

            builder.Property(e => e.EstadoLaboral)
                .HasMaxLength(50)
                .HasDefaultValue("Activo");

            builder.Property(e => e.Salario)
                .HasColumnType("decimal(18,2)");

            // Índices
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.NumeroIdentificacion).IsUnique();

            // Relaciones
            builder.HasOne(e => e.Rol)
                .WithMany(r => r.Empleados)
                .HasForeignKey(e => e.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.OrdenesTrabajo)
                .WithOne(o => o.EmpleadoPrincipal)
                .HasForeignKey(o => o.EmpleadoPrincipalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
