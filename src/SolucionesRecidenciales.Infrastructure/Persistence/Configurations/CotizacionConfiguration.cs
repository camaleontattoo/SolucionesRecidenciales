using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class CotizacionConfiguration : IEntityTypeConfiguration<Cotizacion>
    {
        public void Configure(EntityTypeBuilder<Cotizacion> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Cotizaciones");

            // Configuración de la clave primaria
            builder.HasKey(c => c.Id);

            // Configuración de propiedades
            builder.Property(c => c.NumeroCotizacion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");

            builder.Property(c => c.NumeroCuenta)
                .HasMaxLength(50);

            builder.Property(c => c.Banco)
                .HasMaxLength(100);

            builder.Property(c => c.TipoCuenta)
                .HasMaxLength(50);

            builder.Property(c => c.Notas)
                .HasMaxLength(500);

            builder.Property(c => c.MontoTotal)
                .HasColumnType("decimal(18,2)");

            // Índices
            builder.HasIndex(c => c.NumeroCotizacion).IsUnique();

            // Relaciones
            builder.HasOne(c => c.Edificio)
                .WithMany(e => e.Cotizaciones)
                .HasForeignKey(c => c.EdificioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Cotizaciones)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
