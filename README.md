# Sistema de Gestión de Incidencias

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue)](https://dotnet.microsoft.com/download/dotnet-framework/4.8)
[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5-brightgreen)](https://docs.microsoft.com/es-es/aspnet/mvc/overview/getting-started/introduction/getting-started)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6-orange)](https://docs.microsoft.com/es-es/ef/ef6/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red)](https://www.microsoft.com/es-es/sql-server)

Aplicación web empresarial desarrollada con ASP.NET MVC 5 para la gestión completa de incidencias y tickets de soporte técnico. Esta solución permite a los equipos de TI administrar, asignar y resolver incidencias de manera eficiente mientras mantiene informados a todos los involucrados.

![Vista previa de la aplicación](https://via.placeholder.com/800x400?text=Vista+Previa+SistemaGestionIncidencias)

## 📋 Características Principales

- ✅ **Gestión completa de incidencias**:
  - Creación, seguimiento, asignación y resolución de incidencias
  - Historial completo de cambios y actualizaciones
  - Sistema de priorización y categorización personalizable
- 🔍 **Búsqueda y filtrado avanzado**:
  - Filtros dinámicos multicampo
  - Búsqueda en tiempo real con AJAX
  - Vista personalizable de incidencias
- 📱 **Diseño completamente responsivo**:
  - Compatible con todos los dispositivos
  - Interfaz optimizada con Bootstrap 5
  - Experiencia de usuario fluida y moderna

## 🛠️ Arquitectura y Tecnologías

### Stack Tecnológico

- **Frontend**:

  - HTML5, CSS3, JavaScript
  - Bootstrap 5
  - jQuery y DataTables
  - AJAX para operaciones asíncronas

- **Backend**:

  - ASP.NET MVC 5
  - C# (.NET Framework 4.8)
  - Entity Framework 6 (Code First)
  - SQL Server

- **Patrones de Diseño**:
  - Arquitectura en capas
  - Patrón Repository
  - Dependency Injection (Unity Container)
  - Unit of Work

## 🚀 Instalación y Configuración

### Requisitos Previos

- Visual Studio 2019 o superior
- SQL Server 2016 o superior
- .NET Framework 4.8
- Git

### Pasos de Instalación

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/ElianDev55/SistemaGestionIncidencias.git
   cd SistemaGestionIncidencias
   ```

2. **Configurar la base de datos**

   - Abrir SQL Server Management Studio
   - Crear una nueva base de datos: `GestionIncidenciasDB`
   - Ejecutar el script de inicialización ubicado en `/Scripts/InitialSchema.sql`

3. **Configurar la cadena de conexión**

   - Abrir el archivo `Web.config`
   - Modificar la siguiente sección:
     ```xml
     <connectionStrings>
       <add name="GestionIncidenciasContext"
            connectionString="Server=NOMBRE_SERVIDOR;Database=GestionIncidenciasDB;User Id=usuario;Password=contraseña;"
            providerName="System.Data.SqlClient"/>
     </connectionStrings>
     ```

4. **Restaurar paquetes NuGet**

   - En Visual Studio, abrir la Consola del Administrador de Paquetes:
     ```
     Update-Package -reinstall
     ```

5. **Ejecutar migraciones**

   - En la misma consola:
     ```
     Update-Database
     ```

6. **Compilar y ejecutar**
   - Presionar F5 o hacer clic en "IIS Express" para iniciar la aplicación
   - Por defecto, el sistema creará un usuario administrador:
     - Usuario: `admin@sistema.com`
     - Contraseña: `Admin123!`

## 📂 Estructura del Proyecto

```
SistemaGestionIncidencias/
│
├── App_Start/                   # Configuraciones iniciales
│   ├── BundleConfig.cs          # Configuración de bundles CSS/JS
│   ├── FilterConfig.cs          # Filtros globales
│   ├── RouteConfig.cs           # Configuración de rutas
│   └── UnityConfig.cs           # Configuración de inyección de dependencias
│
├── Controllers/                 # Controladores MVC
│   ├── AccountController.cs     # Control de acceso y autenticación
│   ├── DashboardController.cs   # Panel principal
│   ├── IncidenciasController.cs # Gestión de incidencias
│   └── ...
│
├── Models/                      # Modelos de datos
│   ├── Entities/                # Entidades del dominio
│   ├── ViewModels/              # Modelos para las vistas
│   ├── Repository/              # Repositorios de acceso a datos
│   └── Context/                 # Contexto de Entity Framework
│
├── Views/                       # Vistas Razor
│   ├── Account/                 # Vistas de autenticación
│   ├── Dashboard/               # Vistas del panel principal
│   ├── Incidencias/             # Vistas de gestión de incidencias
│   └── ...
│
├── Scripts/                     # Scripts JavaScript
│   ├── app/                     # Scripts personalizados
│   └── lib/                     # Librerías externas
│
├── Content/                     # Archivos CSS y recursos
│   ├── css/                     # Estilos propios
│   ├── themes/                  # Temas visuales
│   └── images/                  # Imágenes e iconos
│
├── Services/                    # Servicios de lógica de negocio
│   ├── IncidenciaService.cs     # Servicio de incidencias
│   ├── NotificacionService.cs   # Servicio de notificaciones
│   └── ...
│
└── Utilities/                   # Clases de utilidad
    ├── Extensions/              # Métodos de extensión
    ├── Helpers/                 # Clases auxiliares
    └── ...
```
