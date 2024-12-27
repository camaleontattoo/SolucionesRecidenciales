# Soluciones Residenciales

## Descripción del Proyecto
Sistema de gestión integral para administración de servicios residenciales, desarrollado con .NET Core y siguiendo arquitectura CQRS.

## Requisitos Previos
- .NET 9.0 SDK
- SQL Server
- Visual Studio 2022 o Visual Studio Code

## Configuración del Proyecto

### Clonar el Repositorio
```bash
git clone https://github.com/tu-usuario/SolucionesRecidenciales.git
cd SolucionesRecidenciales
```

### Configurar Base de Datos
1. Actualizar cadena de conexión en `appsettings.json`
2. Ejecutar migraciones:
```bash
dotnet ef database update
```

### Ejecutar la Aplicación
```bash
dotnet run --project src/SolucionesRecidenciales.WebApi
```

## Arquitectura
- Patrón CQRS
- Arquitectura Limpia (Clean Architecture)
- Mediatr para separación de comandos y consultas
- Entity Framework Core
- Swagger para documentación de API

## Características Principales
- Gestión de Clientes
- Control de Inventario
- Órdenes de Trabajo
- Cotizaciones
- Gestión de Empleados

## Contribuciones
1. Haz un fork del proyecto
2. Crea tu rama de características (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## Licencia
Distribuido bajo Licencia MIT. Ver `LICENSE` para más información.

## Contacto
Tu Nombre - tu.email@example.com

Proyecto Link: [https://github.com/tu-usuario/SolucionesRecidenciales](https://github.com/tu-usuario/SolucionesRecidenciales)
