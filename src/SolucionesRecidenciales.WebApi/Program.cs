using SolucionesRecidenciales.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SolucionesRecidenciales.Infrastructure.Persistence;
using MediatR;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace SolucionesRecidenciales.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();

        // Configure Kestrel to listen on specific ports
        services.Configure<KestrelServerOptions>(
            Configuration.GetSection("Kestrel")
        );

        // Configure Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "Soluciones Residenciales API", 
                Version = "v1",
                Description = "API for Soluciones Residenciales project"
            });
        });

        // Configure Infrastructure services
        services.AddInfrastructure(Configuration);

        // Configure MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        // Configure DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            )
        );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Soluciones Residenciales API v1");
                c.RoutePrefix = string.Empty; // This will make Swagger UI the default page
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
