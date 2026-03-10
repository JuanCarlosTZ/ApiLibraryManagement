# ApiLibraryManagement

## Requisitos previos

Antes de iniciar el proyecto, asegúrate de tener instalados los siguientes elementos:

- **.NET 10 SDK**: (https://dotnet.microsoft.com/en-us/download/dotnet/10.0)  
- **Visual Studio Code**  
- **Docker Desktop**  
- **Navegador Web**  
- **Opcional**: Postman o navegador para probar endpoints  

---

## Resumen y Avances

Este proyecto fue creado siguiendo buenas prácticas de arquitectura y diseño moderno, utilizando tecnologías robustas y escalables.

### Arquitectura y Frameworks

- **.NET 10**: Framework moderno, robusto y de alto rendimiento, que permite escalabilidad y soporte a largo plazo.  
- **Code First con Entity Framework Core**:  
  - Permite definir la estructura de la base de datos a partir de los modelos de C#.  
  - Facilita la gestión de migraciones y actualizaciones de esquema.

### Uso de Docker y SQL Server / Azure SQL Edge

- Permite un entorno consistente para desarrollo y pruebas.  
- Facilita la inicialización de la base de datos con scripts y separación de entornos (desarrollo vs producción).  
- Mantiene los datos persistentes mediante volúmenes de Docker (`sqlserverdata`).

### Variables de entorno (`.env`)

- Parametrización de contraseñas, usuarios, puertos y nombres de base de datos.  
- Evita hardcodear credenciales sensibles.  
- Facilita el despliegue en diferentes entornos sin modificar código.

### Inicialización de datos (Seeder)

- **Endpoint `/seed`**:  
  - Permite poblar la base de datos con datos de prueba de forma rápida.  
  - Facilita pruebas funcionales sin necesidad de manipular la base de datos manualmente.  
  - Mejora la reproducibilidad para desarrolladores y testers.

---

## Principios de diseño aplicados

### Inversión de Dependencias (Dependency Inversion Principle)

- La API y la capa de aplicación dependen de **interfaces**, no de implementaciones concretas.  
- Permite cambiar la persistencia o servicios sin afectar la lógica de negocio.

### Separación de responsabilidades (SoC)

- Cada capa tiene una función clara: **Dominio, Lógica de Negocio, Infraestructura o Presentación**.  
- Facilita mantenimiento, pruebas unitarias y escalabilidad.

### Uso de patrones comunes en .NET

- **Repository Pattern**: encapsula operaciones con la base de datos.  
- **Unit of Work** (implícito con EF Core): manejo de transacciones.  
- **Service Layer**: servicios que coordinan operaciones entre repositorios y lógica de negocio.

---

# Iniciarlicar el proyecto

1. Abrir el proyecto con Visual Studio Code y asegurarse de estar en la Raiz del proyecto.

2. Clonar el archivo ``.env-template`` a ``.env`` en la raíz del proyecto y ajustar parametros (Se pueden dejar los que estan por defectos para fines de prueba)


3. Descarga todas las dependencias del proyecto
```
dotnet restore
```

4. Levantar la base de datos.
```
docker-compose up -d
```

5. Iniciar migraciones de EF Core
```
dotnet ef migrations add InitialCreate
```

6. Crear base de datos y tablas
```
dotnet ef database update
```

7. Ejecutart el proyecto. Correr el proyecto desde el archivo ``Program.cs`` haciendo clic en play. Alternativa, ejecutar el comando ``dotnet run``


8. Inicializar data en la base de datos
```
post method 
http://localhost:5054/seed
```

