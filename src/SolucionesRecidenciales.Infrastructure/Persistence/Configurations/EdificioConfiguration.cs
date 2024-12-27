using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class EdificioConfiguration : IEntityTypeConfiguration<Edificio>
    {
        public void Configure(EntityTypeBuilder<Edificio> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Edificios");

            // Configuración de la clave primaria
            builder.HasKey(e => e.Id);

            // Configuración de propiedades
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.NIT)
                .HasMaxLength(20);

            builder.Property(e => e.Telefono)
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .HasMaxLength(100);

            // Relaciones
            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Edificios)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.OrdenesTrabajo)
                .WithOne(o => o.Edificio)
                .HasForeignKey(o => o.EdificioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Cotizaciones)
                .WithOne(c => c.Edificio)
                .HasForeignKey(c => c.EdificioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
