# Gestión de Pacientes

Proyecto ASP.NET Core 9 para la gestión de pacientes en un hospital. Permite realizar operaciones CRUD sobre pacientes y expone una API REST documentada con Swagger/OpenAPI.

---

## Requisitos Previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local o remoto)
- Visual Studio 2022 o superior

---

## Configuración Inicial

1. **Clona el repositorio**2. **Configura la cadena de conexión**
   - Edita el archivo `appsettings.json` y actualiza el valor de `ConnectionStrings:ConnectionDB` con los datos de tu servidor SQL Server.
2. **Configura la cadena de conexión**
   - Edita el archivo `appsettings.json` y actualiza el valor de `ConnectionStrings:ConnectionDB` con los datos de tu servidor SQL Server.
3. **Restaura los paquetes NuGet**
   - Visual Studio lo hace automáticamente al abrir la solución, o ejecuta:
4. **Aplica las migraciones y crea la base de datos**
   - Abre la consola del administrador de paquetes o terminal y ejecuta:
> Asegúrate de tener instalado el paquete `Microsoft.EntityFrameworkCore.Tools`.

---

## Ejecución del Proyecto

1. **Compila y ejecuta**
   - Desde Visual Studio: presiona `F5` o selecciona __Iniciar depuración__.
   - Desde terminal:
2. **Accede a la documentación de la API**
   - Al iniciar, serás redirigido automáticamente a la documentación Swagger en:  
     [https://localhost:puerto/swagger/index.html](https://localhost:puerto/swagger/index.html)

---

## Endpoints Principales

- `GET /api/hospital` — Listar todos los pacientes
- `GET /api/hospital/{id}` — Obtener paciente por ID
- `POST /api/hospital/guardar` — Crear paciente
- `PUT /api/hospital/{id}` — Actualizar paciente
- `DELETE /api/hospital/{id}` — Eliminar paciente

---

## Estructura del Proyecto

- `Controllers/` — Controladores de la API (`HospitalController.cs`)
- `Models/` — Modelos de datos y contexto de base de datos (`Paciente.cs`, `HospitalDbContext.cs`, `ApiResponse.cs`)
- `Program.cs` — Configuración y arranque de la aplicación
- `appsettings.json` — Configuración de la cadena de conexión y otros parámetros

---

## Modelos Principales

### Paciente
---

## Notas Técnicas

- El proyecto utiliza validaciones de datos mediante anotaciones en los modelos.
- Swagger/OpenAPI está habilitado solo en entorno de desarrollo.
- El controlador principal es `HospitalController`, que implementa todas las operaciones CRUD.
- El contexto de base de datos es `HospitalDbContext`, configurado en `Program.cs` para usar SQL Server.
- La respuesta de la API está estandarizada usando el modelo `ApiResponse<T>`.

---

## Recursos

- [Documentación oficial ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/)
- [Documentación oficial Entity Framework Core](https://learn.microsoft.com/es-es/ef/core/)

---

Si tienes dudas o problemas, revisa la documentación oficial o abre un issue en el repositorio.
