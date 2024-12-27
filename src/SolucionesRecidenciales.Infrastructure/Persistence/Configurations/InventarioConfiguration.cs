using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            // Configuración de la tabla
            builder.ToTable("Inventarios");

            // Configuración de la clave primaria
            builder.HasKey(i => i.Id);

            // Configuración de propiedades
            builder.Property(i => i.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Descripcion)
                .HasMaxLength(200);

            builder.Property(i => i.UnidadMedida)
                .HasMaxLength(20);

            builder.Property(i => i.UbicacionBodega)
                .HasMaxLength(100);

            builder.Property(i => i.PrecioUnitario)
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.CostoUnitario)
                .HasColumnType("decimal(18,2)");

            // Índices
            builder.HasIndex(i => i.Nombre);
        }
    }
}
