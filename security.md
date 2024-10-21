# Seguridad [Indice](README.md)
En este módulo usaremos un proyecto ya previamente creado
lo encotraremos en la carpeta [proyectos](./proyectos/)



# CONCEPTOS TEÓRICOS IMPORTANTES

Introducción al Ejercicio: Implementación de una API REST Segura con [ASP.NET](http://ASP.NET) 
Core Identity y JWT en .NET 8

En este ejercicio, se ha desarrollado una API REST sencilla utilizando .NET 8 y C#. El objetivo 
principal es demostrar cómo implementar autenticación y autorización en una aplicación web moderna, 
utilizando herramientas y prácticas recomendadas. A continuación, se detallan las librerías 
utilizadas y los elementos conceptuales clave presentes en el ejercicio.


Librerías y Paquetes Utilizados


1. Microsoft.AspNetCore.Identity.EntityFrameworkCore

•	Descripción: Proporciona la implementación de [ASP.NET](http://ASP.NET) Core Identity que utiliza 
Entity Framework Core para gestionar el almacenamiento de usuarios y roles en una base de datos.  
•	Uso en el ejercicio: Permite gestionar la creación, autenticación y autorización de usuarios 
dentro de la aplicación. Facilita operaciones como el registro, inicio de sesión y manejo de roles.  

2.	Microsoft.EntityFrameworkCore.InMemory

•	Descripción: Es un proveedor de base de datos en memoria para Entity Framework Core. Ideal para 
desarrollo y pruebas, ya que no requiere una base de datos física.  
•	Uso en el ejercicio: Almacena temporalmente los datos de usuarios y roles en memoria, 
simplificando el proceso de configuración y evitando la necesidad de instalar y configurar una base de 
datos real.  

3.	Microsoft.AspNetCore.Authentication.JwtBearer

•	Descripción: Proporciona middleware para autenticar solicitudes HTTP utilizando JSON Web Tokens 
(JWT) en aplicaciones [ASP.NET](http://ASP.NET) Core.  
•	Uso en el ejercicio: Configura la aplicación para validar tokens JWT en cada solicitud entrante, 
garantizando que solo los usuarios autenticados puedan acceder a ciertos recursos.  

4.	Microsoft.IdentityModel.Tokens

•	Descripción: Ofrece clases y métodos para trabajar con tokens de seguridad, incluyendo la 
generación y validación de tokens JWT.  
•	Uso en el ejercicio: Utilizada para crear y firmar tokens JWT al momento del inicio de sesión, 
y para validar dichos tokens en solicitudes posteriores.  

5.	System.IdentityModel.Tokens.Jwt

•	Descripción: Proporciona APIs para crear, serializar y validar tokens JWT.  
•	Uso en el ejercicio: Facilita la generación de tokens JWT personalizados con claims específicos 
para cada usuario.


Elementos Conceptuales Presentes en el Ejercicio


1. API REST

•	Descripción: Una API (Application Programming Interface) que utiliza los principios de 
Representational State Transfer (REST) para permitir la comunicación entre clientes y servidores a 
través de HTTP.  
•	Uso en el ejercicio: La aplicación expone endpoints HTTP que permiten a los clientes interactuar 
con los recursos (por ejemplo, registrar usuarios, iniciar sesión y obtener datos protegidos).  

2.	Autenticación y Autorización

•	Autenticación: Proceso de verificar la identidad de un usuario, generalmente mediante credenciales 
como correo electrónico y contraseña.  
•	Autorización: Proceso de determinar si un usuario autenticado tiene permiso para acceder a un 
recurso o realizar una acción específica.  
•	Uso en el ejercicio: Se implementa la autenticación mediante el registro y login de usuarios, y 
la autorización al proteger ciertos endpoints con el atributo [Authorize].  

3.	[ASP.NET](http://ASP.NET) Core Identity

•	Descripción: Framework integrado en [ASP.NET](http://ASP.NET) Core que facilita la gestión de 
usuarios, roles y políticas de seguridad.  
•	Uso en el ejercicio: Maneja las operaciones relacionadas con usuarios, como el registro, la 
validación de credenciales y la asignación de roles.  

4.	JSON Web Tokens (JWT)

•	Descripción: Estándar abierto que define una forma compacta y autónoma de transmitir información 
de forma segura entre un emisor y un receptor como un objeto JSON firmado.  
•	Uso en el ejercicio: Al iniciar sesión, se genera un token JWT que contiene información (claims) 
sobre el usuario. Este token se utiliza para autenticar y autorizar solicitudes subsecuentes.  

5.	Entity Framework Core

•	Descripción: ORM (Object-Relational Mapper) que permite interactuar con bases de datos utilizando 
objetos .NET, eliminando la necesidad de escribir código SQL manualmente.  
•	Uso en el ejercicio: Se utiliza para interactuar con la base de datos en memoria, almacenando y 
recuperando información de usuarios y roles.  

6.	Inyección de Dependencias

• Descripción: Patrón de diseño que permite gestionar las dependencias entre clases de forma flexible 
y modular. • Uso en el ejercicio: Servicios como UserManager y SignInManager se inyectan en los 
controladores a través del constructor, facilitando las pruebas y el mantenimiento del código. 

7. Configuración de Servicios y Middleware

•	Descripción: En [ASP.NET](http://ASP.NET) Core, los servicios (como Identity y autenticación) se 
configuran en el método ConfigureServices, y los middleware (como UseAuthentication y UseAuthorization)
 se configuran en el método Configure.  
•	Uso en el ejercicio: En el archivo Program.cs, se agregan y configuran los servicios necesarios, 
y se establece la canalización de middleware para manejar las solicitudes HTTP.  

8.	Controladores y Rutas

•	Descripción: Los controladores contienen acciones que responden a las solicitudes HTTP, y las 
rutas determinan cómo se accede a esas acciones.  
•	Uso en el ejercicio: Se crearon dos controladores: AuthController para manejar la autenticación, 
y ValoresController para exponer un endpoint protegido que devuelve datos solo si el usuario está 
autenticado.  

9.	Atributos de Acción y Controlador

•	Descripción: Los atributos como [ApiController], [Route], [HttpPost] y [Authorize] decoran clases 
y métodos para especificar comportamientos y restricciones.  
•	Uso en el ejercicio:  
•	[ApiController]: Indica que el controlador responde a solicitudes de API.  
•	[Route("api/[controller]")]: Define la ruta base del controlador.  
•	[HttpPost("login")] y [HttpPost("registrar")]: Especifican el verbo HTTP y la ruta para las 
acciones.  
•	[Authorize]: Restringe el acceso a las acciones solo a usuarios autenticados.  

10.	Manejo de Errores y Respuestas HTTP

•	Descripción: Es esencial proporcionar respuestas significativas al cliente, incluyendo códigos 
de estado HTTP y mensajes de error claros.  
•	Uso en el ejercicio:  
•	Ok(): Devuelve un código 200 junto con datos cuando la operación es exitosa.  
•	BadRequest(): Devuelve un código 400 cuando hay errores en la solicitud.  
•	Unauthorized(): Devuelve un código 401 cuando las credenciales son inválidas.


## Resumen del Flujo de la Aplicación


1. Registro de Usuario:

•	El cliente envía una solicitud POST a /api/auth/registrar con el correo electrónico y contraseña.  
•	El AuthController utiliza UserManager para crear un nuevo usuario en la base de datos.  
•	Si el registro es exitoso, se devuelve una respuesta Ok indicando el éxito.  

2.	Inicio de Sesión:  
•	El cliente envía una solicitud POST a /api/auth/login con el correo electrónico y contraseña.  
•	El AuthController verifica las credenciales utilizando UserManager.  
•	Si las credenciales son correctas, se genera un token JWT que incluye claims con información del 
usuario.  
•	El token JWT se devuelve al cliente en la respuesta.  

3.	Acceso a Recursos Protegidos:  
•	El cliente envía una solicitud GET a /api/valores incluyendo el token JWT en el encabezado 
Authorization.  
•	El middleware de autenticación valida el token y establece el contexto de usuario.  
•	Si el token es válido, el ValoresController responde con los datos solicitados.  
•	Si el token es inválido o no se proporciona, se devuelve una respuesta Unauthorized.

Importancia de los Conceptos Aplicados

•	Seguridad: La implementación de autenticación y autorización es fundamental para proteger los 
recursos de una aplicación y garantizar que solo usuarios autorizados puedan acceder a ellos.  
•	Buenas Prácticas: Utilizar frameworks y librerías estándar como [ASP.NET](http://ASP.NET) Core 
Identity y JWT asegura que la aplicación siga las mejores prácticas de la industria.  
•	Escalabilidad y Mantenibilidad: Al estructurar el código de manera modular y seguir patrones de 
diseño como la inyección de dependencias, se facilita el mantenimiento y la escalabilidad de la 
aplicación a medida que crece en complejidad.  
•	Experiencia del Desarrollador: Utilizar una base de datos en memoria y herramientas proporcionadas 
por el framework simplifica el proceso de desarrollo y permite enfocarse en comprender los conceptos 
clave.

Conclusión

Este ejercicio proporciona una base sólida para comprender cómo implementar seguridad en una API REST 
utilizando tecnologías modernas de .NET. Al integrar [ASP.NET](http://ASP.NET) Core Identity y JWT, se 
logra una gestión efectiva de usuarios y control de acceso a los recursos de la aplicación.



Siguientes Pasos

•	Personalización: Explorar cómo personalizar el modelo de usuario y agregar propiedades adicionales.  
•	Roles y Políticas: Implementar roles de usuario y políticas de autorización para controlar el 
acceso a diferentes partes de la aplicación.  
•	Persistencia Real: Configurar Entity Framework Core para utilizar una base de datos real como 
SQL Server o SQLite.  
•	Manejo de Errores Avanzado: Implementar un manejo de errores más robusto y personalizado.  
•	Mejoras en Seguridad: Utilizar técnicas como el refresco de tokens (refresh tokens), 
almacenamiento seguro de claves y configuración de HTTPS para entornos de producción.




COMO EJECUTAR LA APLICACIÓN


Registrar un nuevo usuario (OJO, es http)

	•	Método: POST
	•	URL: http://localhost:5205/api/auth/registrar
	•	Encabezados:
	•	Content-Type: application/json
	•	Cuerpo (JSON):

{
  "email": "usuario@example.com",
  "password": "ContraseñaSegura123!"
}

{
  "mensaje": "Usuario registrado exitosamente"
}

## Para el password se usa el siguiente enlace 
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-8.0


Iniciar sesión

	•	Método: POST
	•	URL: http://localhost:5205/api/auth/login
	•	Encabezados:
	•	Content-Type: application/json
	•	Cuerpo (JSON):

{
  "email": "usuario@example.com",
  "password": "ContraseñaSegura123!"
}

{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImM5ODZhOGRkLWQwYTctNDlhMC04YWJjLWJhMDVjMWUwMzA0NCIsImVtYWlsIjoidXN1YXJpb0BleGFtcGxlLmNvbSIsIm5iZiI6MTcyOTI4MzE2MCwiZXhwIjoxNzI5Mjg2NzYwLCJpYXQiOjE3MjkyODMxNjB9.3lVSufpjoObkCWvtc1ac-J8u2TzzhF3avkrh8mhti9A"
}

Acceder al endpoint protegido

	•	Método: GET
	•	URL: http://localhost:5205/api/valores
	•	Encabezados:
	•	Authorization: Bearer {token}
	•	Reemplaza {token} con el token obtenido en el paso anterior.
	•	Respuesta esperada:

En Postman hacer:

	1.	Selecciona el método GET y coloca la URL http://localhost:5205/api/valores.
	2.	Ve a la pestaña “Headers” y agrega un nuevo encabezado:
	•	En Key pones: Authorization
	•	En Value pones: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9... (tu token)
	3.	Envía la solicitud.

Deberías ver lo siguiente:

[
  "Valor1",
  "Valor2",
  "Valor3"
]


NOTAS ADICIONALES

	•	Validez del token: Recuerda que el token tiene una expiración 
    definida (en este caso, 1 hora desde su emisión). Si intentas usar un 
    token expirado, recibirás una respuesta de error de autorización. En ese 
    caso, deberás iniciar sesión nuevamente para obtener un nuevo token.
	•	Seguridad: Para mantener la seguridad de tu aplicación, nunca 
    compartas tus tokens JWT ni los incluyas en código fuente que pueda ser 
    visto por otros.
	•	Uso de HTTPS: Aunque para pruebas locales hemos usado HTTP, en un 
    entorno de producción es esencial utilizar HTTPS para proteger la 
    información que se transmite entre el cliente y el servidor.
