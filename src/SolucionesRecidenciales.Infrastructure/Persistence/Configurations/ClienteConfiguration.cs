using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Clientes");

            // Configuración de la clave primaria
            builder.HasKey(c => c.Id);

            // Configuración de propiedades
            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.NIT)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Direccion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Telefono)
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            // Índices
            builder.HasIndex(c => c.NIT).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();

            // Relaciones
            builder.HasMany(c => c.Edificios)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Cotizaciones)
                .WithOne(cot => cot.Cliente)
                .HasForeignKey(cot => cot.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
