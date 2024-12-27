-- Crear base de datos
CREATE DATABASE SolucionesRecidenciales;
GO

USE SolucionesRecidenciales;
GO

-- Tabla de Clientes
CREATE TABLE Clientes (
    ClienteID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    NIT VARCHAR(20) UNIQUE NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Email VARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Edificios
CREATE TABLE Edificios (
    EdificioID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    NIT VARCHAR(20),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

-- Tabla de Roles de Empleados
CREATE TABLE Roles (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(200)
);

-- Tabla de Empleados
CREATE TABLE Empleados (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    RolID INT NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    FechaContratacion DATE,
    Especialidad VARCHAR(100),
    FechaNacimiento DATE,
    NumeroIdentificacion VARCHAR(20) UNIQUE,
    FechaIngreso DATE,
    Salario DECIMAL(10,2),
    EstadoLaboral VARCHAR(50) DEFAULT 'Activo',
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

-- Tabla de Vehículos
CREATE TABLE Vehiculos (
    VehiculoID INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(50) NOT NULL, -- Moto, Carro, etc.
    Placa VARCHAR(20) UNIQUE NOT NULL,
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Año INT
);

-- Tabla de Inventario/Bodega
CREATE TABLE Inventario (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200),
    Cantidad INT NOT NULL DEFAULT 0,
    UnidadMedida VARCHAR(20),
    PrecioUnitario DECIMAL(10,2),
    FechaUltimaActualizacion DATETIME DEFAULT GETDATE(),
    StockMinimo INT DEFAULT 0,
    UbicacionBodega VARCHAR(100),
    FechaUltimaEntrada DATETIME,
    FechaUltimaSalida DATETIME,
    CostoUnitario DECIMAL(10,2)
);

-- Tabla de Mantenimientos
CREATE TABLE Mantenimientos (
    MantenimientoID INT IDENTITY(1,1) PRIMARY KEY,
    EdificioID INT NOT NULL,
    EmpleadoID INT NOT NULL,
    FechaProgramada DATE NOT NULL,
    FechaEjecucion DATE,
    Descripcion VARCHAR(500),
    Estado VARCHAR(50), -- Pendiente, En Progreso, Completado
    FOREIGN KEY (EdificioID) REFERENCES Edificios(EdificioID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
);

-- Tabla de Cotizaciones (Actualizada)
CREATE TABLE Cotizaciones (
    CotizacionID INT IDENTITY(1,1) PRIMARY KEY,
    EdificioID INT NOT NULL,  -- Relación directa con el edificio
    ClienteID INT NOT NULL,
    NumeroCotizacion VARCHAR(50) UNIQUE NOT NULL,  -- Número único de cotización
    FechaCotizacion DATE NOT NULL,
    FechaVencimiento DATE,
    MontoTotal DECIMAL(12,2) NOT NULL,
    Estado VARCHAR(50) NOT NULL, -- Pendiente, Aprobada, Rechazada, En Revisión
    
    -- Información de Pago
    NumeroCuenta VARCHAR(50),  -- Número de cuenta para consignaciones
    Banco VARCHAR(100),
    TipoCuenta VARCHAR(50),  -- Ahorros, Corriente, etc.
    
    -- Notas adicionales
    Notas TEXT,
    
    FOREIGN KEY (EdificioID) REFERENCES Edificios(EdificioID),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

-- Tabla de Órdenes de Trabajo
CREATE TABLE OrdenesTrabajo (
    OrdenTrabajoID INT IDENTITY(1,1) PRIMARY KEY,
    EdificioID INT NOT NULL,
    TipoServicio VARCHAR(100) NOT NULL,
    FechaSolicitud DATE NOT NULL DEFAULT GETDATE(),
    FechaProgramada DATE,
    FechaEjecucion DATE,
    Estado VARCHAR(50) NOT NULL DEFAULT 'Pendiente', 
    PrioridadServicio INT CHECK (PrioridadServicio BETWEEN 1 AND 5),
    
    -- Detalles de Empleados
    EmpleadoPrincipal INT,
    EmpleadosAdicionales VARCHAR(200), -- JSON o lista de IDs
    
    -- Materiales Utilizados (almacenar como JSON para flexibilidad)
    MaterialesUtilizados NVARCHAR(MAX),
    
    -- Tiempos
    TiempoEstimado DECIMAL(5,2), -- Horas
    TiempoReal DECIMAL(5,2),     -- Horas
    
    -- Costos
    CostoMateriales DECIMAL(10,2) DEFAULT 0,
    CostoManoObra DECIMAL(10,2) DEFAULT 0,
    
    -- Observaciones
    Observaciones NVARCHAR(MAX),
    
    FOREIGN KEY (EdificioID) REFERENCES Edificios(EdificioID),
    FOREIGN KEY (EmpleadoPrincipal) REFERENCES Empleados(EmpleadoID)
);

-- Tabla de Bitácora de Cambios (para auditoría)
CREATE TABLE BitacoraCambios (
    BitacoraID INT IDENTITY(1,1) PRIMARY KEY,
    Tabla VARCHAR(100) NOT NULL,
    RegistroID INT NOT NULL,
    Accion VARCHAR(50) NOT NULL, -- INSERT, UPDATE, DELETE
    Usuario VARCHAR(100),
    FechaCambio DATETIME DEFAULT GETDATE(),
    DetallesCambio NVARCHAR(MAX)
);

-- Tabla de Control de Vehículos
CREATE TABLE ControlVehiculos (
    VehiculoID INT IDENTITY(1,1) PRIMARY KEY,
    Placa VARCHAR(20) UNIQUE NOT NULL,
    Marca VARCHAR(100),
    Modelo VARCHAR(100),
    Año INT,
    TipoVehiculo VARCHAR(50), -- Moto, Camioneta, Camión
    EstadoActual VARCHAR(50) DEFAULT 'Disponible',
    UltimoMantenimiento DATE,
    ProximoMantenimiento DATE,
    KilometrajeActual DECIMAL(10,2),
    CostoMantenimientoUltimo DECIMAL(10,2)
);

-- Índices para mejorar rendimiento
CREATE INDEX IX_Cotizaciones_EdificioID ON Cotizaciones(EdificioID);
CREATE INDEX IX_Cotizaciones_ClienteID ON Cotizaciones(ClienteID);
CREATE INDEX IX_Cotizaciones_Estado ON Cotizaciones(Estado);
CREATE INDEX IX_Cotizaciones_FechaCotizacion ON Cotizaciones(FechaCotizacion);

CREATE INDEX IX_OrdenesTrabajo_EdificioID ON OrdenesTrabajo(EdificioID);
CREATE INDEX IX_OrdenesTrabajo_Estado ON OrdenesTrabajo(Estado);
CREATE INDEX IX_OrdenesTrabajo_FechaSolicitud ON OrdenesTrabajo(FechaSolicitud);

CREATE INDEX IX_ControlVehiculos_Placa ON ControlVehiculos(Placa);
CREATE INDEX IX_ControlVehiculos_Estado ON ControlVehiculos(EstadoActual);

-- Insertar Rol inicial
INSERT INTO Roles (NombreRol, Descripcion) VALUES 
('Administrador', 'Administrador con acceso total al sistema');
GO

-- Procedimiento almacenado para registrar cambios en bitácora
CREATE PROCEDURE RegistrarCambioBitacora
    @Tabla VARCHAR(100),
    @RegistroID INT,
    @Accion VARCHAR(50),
    @Usuario VARCHAR(100),
    @DetallesCambio NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO BitacoraCambios 
    (Tabla, RegistroID, Accion, Usuario, DetallesCambio)
    VALUES 
    (@Tabla, @RegistroID, @Accion, @Usuario, @DetallesCambio)
END
GO
