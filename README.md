 Pokémon Web App (.NET Core 8 + API)

Aplicación web desarrollada con ASP.NET Core 8 (MVC) que consume la API pública PokeAPI
 para mostrar un listado dinámico de Pokémon con funcionalidades avanzadas de filtrado, exportación y manejo eficiente de datos.

 Descripción

Este proyecto implementa una arquitectura web basada en MVC, consumiendo datos desde una API externa y transformándolos para su visualización en una interfaz interactiva.

Incluye funcionalidades como filtrado dinámico, paginación manual, exportación a Excel y envío de información por correo, además de optimizaciones como caching local para mejorar el rendimiento.

 Tecnologías
C#
ASP.NET Core 8 (MVC)
.NET 8
JavaScript
Bootstrap
API REST (PokeAPI)
Async / Await
- Funcionalidades
- Listado dinámico de Pokémon
- Filtro por nombre (búsqueda en tiempo real)
- Filtro por especie (dropdown desde API)
- Paginación manual
- Exportación a Excel
- Envío de información por correo (individual o general)
- Manejo de llamadas asíncronas
- Manejo de errores en consumo de API
- Caching local para optimización de llamadas
- Visualización de imagen y datos del Pokémon
- Consumo de API

Se integran los siguientes endpoints de PokeAPI:

/pokemon
/pokemon/{id}
/pokemon-species/{id}

 Nota:
La especie requiere una segunda llamada, por lo que se implementó caching para evitar solicitudes redundantes.

 Características Técnicas
Arquitectura MVC bien estructurada
Separación de responsabilidades (Controllers, Services, Views)
Uso de servicios para consumo de API
Manejo de asincronía con async/await
Optimización mediante caching
Código limpio y mantenible
 Instalación
git clone https://github.com/Jperez220/PokeApp.git
cd PokeApp
dotnet restore
dotnet run
 Ejecución

Abrir en navegador:

https://localhost:5001
 Objetivo

Demostrar habilidades en:

Consumo de APIs externas
Desarrollo con ASP.NET Core
Manejo de asincronía
Optimización de rendimiento
Construcción de interfaces dinámicas
Posibles mejoras
Integración con base de datos
Sistema de favoritos
Autenticación de usuarios
Mejoras en UI/UX
Implementación de API propia

👨‍💻 Autor

Juan Pérez

Proyecto desarrollado como práctica técnica enfocada en consumo de APIs, optimización y desarrollo Full Stack.
