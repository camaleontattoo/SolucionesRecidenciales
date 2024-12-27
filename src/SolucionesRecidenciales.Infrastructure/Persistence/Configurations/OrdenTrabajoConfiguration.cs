using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucionesRecidenciales.Domain.Entities;

namespace SolucionesRecidenciales.Infrastructure.Persistence.Configurations
{
    public class OrdenTrabajoConfiguration : IEntityTypeConfiguration<OrdenTrabajo>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajo> builder)
        {
            // Configuración de la tabla
            builder.ToTable("OrdenesTrabajo");

            // Configuración de la clave primaria
            builder.HasKey(o => o.Id);

            // Configuración de propiedades
            builder.Property(o => o.TipoServicio)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");

            builder.Property(o => o.EmpleadosAdicionales)
                .HasMaxLength(200);

            builder.Property(o => o.MaterialesUtilizados)
                .HasMaxLength(500);

            builder.Property(o => o.TiempoEstimado)
                .HasColumnType("decimal(10,2)");

            builder.Property(o => o.TiempoReal)
                .HasColumnType("decimal(10,2)");

            builder.Property(o => o.CostoMateriales)
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CostoManoObra)
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Observaciones)
                .HasMaxLength(500);

            // Relaciones
            builder.HasOne(o => o.Edificio)
                .WithMany(e => e.OrdenesTrabajo)
                .HasForeignKey(o => o.EdificioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.EmpleadoPrincipal)
                .WithMany(e => e.OrdenesTrabajo)
                .HasForeignKey(o => o.EmpleadoPrincipalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
