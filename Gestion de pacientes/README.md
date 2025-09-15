# Gesti�n de Pacientes

Proyecto ASP.NET Core 9 para la gesti�n de pacientes en un hospital. Permite realizar operaciones CRUD sobre pacientes y expone una API REST documentada con Swagger/OpenAPI.

---

## Requisitos Previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local o remoto)
- Visual Studio 2022 o superior

---

## Configuraci�n Inicial

1. **Clona el repositorio**2. **Configura la cadena de conexi�n**
   - Edita el archivo `appsettings.json` y actualiza el valor de `ConnectionStrings:ConnectionDB` con los datos de tu servidor SQL Server.
2. **Configura la cadena de conexi�n**
   - Edita el archivo `appsettings.json` y actualiza el valor de `ConnectionStrings:ConnectionDB` con los datos de tu servidor SQL Server.
3. **Restaura los paquetes NuGet**
   - Visual Studio lo hace autom�ticamente al abrir la soluci�n, o ejecuta:
4. **Aplica las migraciones y crea la base de datos**
   - Abre la consola del administrador de paquetes o terminal y ejecuta:
> Aseg�rate de tener instalado el paquete `Microsoft.EntityFrameworkCore.Tools`.

---

## Ejecuci�n del Proyecto

1. **Compila y ejecuta**
   - Desde Visual Studio: presiona `F5` o selecciona __Iniciar depuraci�n__.
   - Desde terminal:
2. **Accede a la documentaci�n de la API**
   - Al iniciar, ser�s redirigido autom�ticamente a la documentaci�n Swagger en:  
     [https://localhost:puerto/swagger/index.html](https://localhost:puerto/swagger/index.html)

---

## Endpoints Principales

- `GET /api/hospital` � Listar todos los pacientes
- `GET /api/hospital/{id}` � Obtener paciente por ID
- `POST /api/hospital/guardar` � Crear paciente
- `PUT /api/hospital/{id}` � Actualizar paciente
- `DELETE /api/hospital/{id}` � Eliminar paciente

---

## Estructura del Proyecto

- `Controllers/` � Controladores de la API (`HospitalController.cs`)
- `Models/` � Modelos de datos y contexto de base de datos (`Paciente.cs`, `HospitalDbContext.cs`, `ApiResponse.cs`)
- `Program.cs` � Configuraci�n y arranque de la aplicaci�n
- `appsettings.json` � Configuraci�n de la cadena de conexi�n y otros par�metros

---

## Modelos Principales

### Paciente
---

## Notas T�cnicas

- El proyecto utiliza validaciones de datos mediante anotaciones en los modelos.
- Swagger/OpenAPI est� habilitado solo en entorno de desarrollo.
- El controlador principal es `HospitalController`, que implementa todas las operaciones CRUD.
- El contexto de base de datos es `HospitalDbContext`, configurado en `Program.cs` para usar SQL Server.
- La respuesta de la API est� estandarizada usando el modelo `ApiResponse<T>`.

---

## Recursos

- [Documentaci�n oficial ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/)
- [Documentaci�n oficial Entity Framework Core](https://learn.microsoft.com/es-es/ef/core/)

---

Si tienes dudas o problemas, revisa la documentaci�n oficial o abre un issue en el repositorio.
