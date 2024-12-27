using Microsoft.EntityFrameworkCore;
using SolucionesRecidenciales.Domain.Entities;
using SolucionesRecidenciales.Domain.Common;
using System.Reflection;

namespace SolucionesRecidenciales.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        // DbSet para cada entidad
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Edificio> Edificios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<OrdenTrabajo> OrdenesTrabajo { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar configuraciones de entidades desde el ensamblado actual
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            // Configuraciones globales
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Edificios)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Edificio>()
                .HasMany(e => e.OrdenesTrabajo)
                .WithOne(o => o.Edificio)
                .HasForeignKey(o => o.EdificioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.OrdenesTrabajo)
                .WithOne(o => o.EmpleadoPrincipal)
                .HasForeignKey(o => o.EmpleadoPrincipalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rol>()
                .HasMany(r => r.Empleados)
                .WithOne(e => e.Rol)
                .HasForeignKey(e => e.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaModificacion = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
