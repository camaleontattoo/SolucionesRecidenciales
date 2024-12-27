using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Vehiculos");

            // Configuración de la clave primaria
            builder.HasKey(v => v.Id);

            // Configuración de propiedades
            builder.Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(v => v.Marca)
                .HasMaxLength(100);

            builder.Property(v => v.Modelo)
                .HasMaxLength(100);

            builder.Property(v => v.TipoVehiculo)
                .HasMaxLength(50);

            builder.Property(v => v.EstadoActual)
                .HasMaxLength(50)
                .HasDefaultValue("Disponible");

            builder.Property(v => v.KilometrajeActual)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.CostoMantenimientoUltimo)
                .HasColumnType("decimal(18,2)");

            // Índices
            builder.HasIndex(v => v.Placa).IsUnique();
        }
    }
}
