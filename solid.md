# Proyectos SOLID [indice](README.md)


## Principios SOLID [return](#proyectos-curso-arquitectura-limpia)

**SOLID** es un acronimo que significa **Single responsability** **Open-Closed** **Liskov Substitution** **Interface Segregation Principle** **Dependency Inversion Principle**
---

## Lista de proyectos
- [**Single Responsability**](#single-responsability-return)


- [**Open/Closed**](#openclosed-return)

- [**Liskov sustitution**](#liskov-sustitution-return)

- [**Interface Segregation**](#segregation-de-la-interface-return)

- [**Dependency Inversion**](#inversión-dependencia-return)


## Single Responsability [return](#lista-de-proyectos)
Este indica que una clase no debería de tener más de una responsabilidad, tomemos como ejemplo el siguiente fragmento de código. 

En la siguiente clase se crean 2 clases. 
 - **User**: representa la entidad usuario usada para crear a un usuario.
 - **User Registry**: Clase usada para el registro en memoria de los usuario (en un futuro podría ser una base de datos). 

**Código en C#**

```c#
using System.Security.Cryptography;
using System.Text;

namespace AppSingleResponsability
{
    internal class User(string username, string password)
    {
        private string username { get; set; } = username;
        private string password { get; set; } = password;

        public override string ToString()=>$"User:[ username:{username}, password:{password}]";
    }

    internal class UserRegistry
    {
        private List<User> users= new List<User>();

        public bool CreateUser(string username, string password) {
            if (username.Length>0 && password.Length>0) {
                /*Encoding password*/
                Console.WriteLine("BEFORE encoding!!!!!");
                var encoding=Encoding.UTF8.GetBytes(password);
                Console.WriteLine(encoding);
                var hashingPassword = SHA256.HashData(encoding);
                var passwordEncrypted = Convert.ToHexString(hashingPassword);

                Console.WriteLine(passwordEncrypted);
                /*END encoding password*/

                /*Create User*/
                User user= new(username, passwordEncrypted);
                users.Add(user);

                Console.WriteLine(user);
                return true;  
                
            }

            return false;
        }


    }
}
```
El problema del código anterior es que dentro de la clase estamos añadiendo la función de encrypción y la función de registrar usuarios dentro de la misma clase.
El problema es que si en algún momento cambiamos el algoritmo de encripción de nuestro código tendríamos que modifica la cllse **UserRegistry** que no tiene que ver la encripción. 


**Código con Single Responsability**

```c#
using System.Security.Cryptography;
using System.Text;

namespace AppSingleResponsability
{
    internal class User2(string username, string password)
    {
        private string username { get; set; } = username;
        private string password { get; set; } = password;

        public override string ToString() => $"User:[ username:{username}, password:{password}]";
    }

    internal class UserRegistry2
    {
        private List<User2> users= new List<User2>();

        public bool CreateUser(string username, string password) {
            if (username.Length>0 && password.Length>0) { 
                var passwordEncrypted=EncryptionPassword.EncryptPass(password);
                User2 user2 = new(username,passwordEncrypted);
                users.Add(user2);
                Console.WriteLine($"{user2}");
                return true;

            }
            return false;
        
        }
        
    }

    internal class EncryptionPassword {

        public static string EncryptPass(string pass) {
            var encoding = Encoding.UTF8.GetBytes(pass);
            Console.WriteLine(encoding);
            var hashingPassword = SHA256.HashData(encoding);
            var passwordEncrypted = Convert.ToHexString(hashingPassword);
            return passwordEncrypted;
        }
    
    }
}
```
En el código anterior ahora separamos la encripción en otra clase, esto dandonos la oportunidad que si llegamos a cambiar el algoritmo, sólo módificamos la clase EncryptionPassword.



## Open/Closed [return](#proyectos-solid-indice)
Las entidades de software (clases, módulos, funciones) deben estar abiertas para la extensión, pero cerradas para la modificación. Esto significa que deberías poder añadir nuevas funcionalidades sin cambiar el código existente. <br>
*La idea principal es que si en algún momento queremos agregar nueva funcionalidad no deberíamos modificar el código existente, si no que deberíamos añadir nuevo código*

Supongamos que tenemos una clase que representa a una calculadora de area para figuras geométricas y quedaría algo asi en C# sin usar el principio, open closed.

El problema del código anterior es que si en algun momento añadimos otra figura geometrica el código tendríamos que modificar la clase AreaCalculator.  

```c#
namespace Responsabilidad2OpenClosed
{

    public class Square( double Width, double Height) {
        public double Width { get; set; } = Width;
        public double Height { get; set; } = Height;
        public override string ToString() => $"Square[width: {Width}, height:{Height}]";

    }

    internal class Triangle(double bas, double height) {
        public double Bas { get; set; } = bas;
        public double Height { get; set; } = height;
    }

    internal class AreaCalculator
    {
        public double AreaShape(object obje) {

            if (obje is Square square)
            {
                return square.Height * square.Width;
            }
            else if (obje is Triangle triangle)
            {
                return (triangle.Bas * triangle.Bas) / 2;
            }
            return 0.0;

        }
    }
}

```

Para solucionarlo podemos usar el polimorfismo que nos va a permitir añadir una interface para la funcionalidad y en la clase AreaCalculator ya no tendríamos que modificarlo cada vez que añadamos una figura geometríca. 

```c#
namespace Responsabilidad2OpenClosed
{
    interface IArea {
        double area();
    }

    internal class Square2(double Width, double Height) : IArea {

        public double Width { get; set; } = Width;
        public double Height { get; set; } = Height;

        
        public double area() {
            return this.Height*this.Width;
        }
    }

    internal class Triangle2(double Base, double Height) : IArea{ 
        public double Base { get; set; }= Base;
        public double Height { get; set; }= Height;

        public double area() {
            return (this.Height * this.Base) / 2;
        }
    
    }




    internal class AreaCalculator2
    {
        public double AreaShape(IArea shape) { 
            return shape.area();
        }

    }
}

```

Esto permitiria que cada vez que se añada una nueva figura geométrica no tengamos que modificar las clases previamente creadas. A esto se le llama principio open-closed. 


## Liskov sustitution [return](#proyectos-solid-indice)
Los objetos de una clase derivada deben poder sustituir a objetos de su clase base sin alterar el correcto funcionamiento del programa. En otras palabras, una subclase debe ser intercambiable con su superclase sin afectar la lógica.


El siguiente código es una pequeña jerarquía de clases que nos permite visualizar un problema donde se puede solucionar utilizando la sustitución de Liskov. 

```c#
namespace Principio3Liskov
{

    interface IAve {
        void volar();
        void nadar();
        void correr();
    }

    class Penguin : IAve
    {
        public void correr()
        {
            throw new Exception();
        }

        public void nadar()
        {
            Console.WriteLine("el pinguino nada rápido");
        }

        public void volar()
        {
            throw new Exception();
        }
    }

    class Eagle : IAve
    {
        public void correr()
        {
            throw new Exception();
        }

        public void nadar()
        {
            Console.WriteLine("El nado del águla sólo lo usa para cazar");
        }

        public void volar()
        {
            Console.WriteLine("vuela casi a mas de 100 kmxh");
        }
    }


    internal class AdminAnimalesVoladores
    {
        public List<IAve> voladores= new List<IAve>();

        public void insertarVoladores(IAve[] aves) {
            foreach (var ave in aves) {
                try {
                    ave.volar();
                    voladores.Add(ave);
                }
                catch (Exception ex) {
                    Console.WriteLine($"no es volador!!! {ex}");
                }

            }

        }
        

    }
}
```
En el anterior código se puede visualizar que se crea una interface donde se añaden varios métodos que representan a lo que puede realizar un Ave, pero el problema es que no todas las Aves pueden realizar las 3 acciones de correr, volar y nadar. 

Para solucionarlo usaremos la sustitución de Liskov. 

```c#
namespace Principio3Liskov
{
    
    interface IVolar {
        void volar();
    }

    interface INadar { 
        void nadar();
    }

    interface ICorrer {
        void correr();
    }

    public class Penguin2 : INadar
    {
        public void nadar()
        {
            Console.WriteLine("El pinguino nada muy rapído");
        }
    }

    public class Eagle2 : INadar, IVolar
    {
        public void nadar()
        {
            Console.WriteLine("águila sólo nada cuando caza");
        }

        public void volar()
        {
            Console.WriteLine("águila vuela a más de 100kmxh");
        }
    }


    internal class AdminAnimalesVoladores2
    {
        public List<IVolar> voladores= new List<IVolar>();

        public void InsertVoladores(IVolar[]data) {
            foreach (var tmp in data) {
                voladores.Add(tmp);
            }
        
        }
    }
}

```

## Segregation de la interface [return](#proyectos-solid-indice)

Es mejor tener muchas interfaces específicas para cada cliente que una interfaz general y grande. Las interfaces deben ser pequeñas y especializadas para evitar obligar a las clases que las implementan a incluir métodos que no necesitan.




```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principio4Interfaces
{
    interface IFunciones {
        void desarrollar();
        void organizar();
        void gestionar();
        void registro();
    }

    class Developer : IFunciones
    {
        public void desarrollar()
        {
            throw new NotImplementedException();
        }

        public void gestionar()
        {
            throw new NotImplementedException();
        }

        public void organizar()
        {
            throw new NotImplementedException();
        }

        public void registro()
        {
            throw new NotImplementedException();
        }
    }


    class Gerente : IFunciones
    {
        public void desarrollar()
        {
            throw new NotImplementedException();
        }

        public void gestionar()
        {
            throw new NotImplementedException();
        }

        public void organizar()
        {
            throw new NotImplementedException();
        }

        public void registro()
        {
            throw new NotImplementedException();
        }
    }


    internal class Empresa
    {
    }
}

```
En el código anterior nosotros tenemos una sola interface que controla
la funcionalidad de los empleados de la empresa causando que algunas clases tengan
algunas funciones que no les corresponden. 
Para solucionarlo deberíamos de usar la **segregación de la interface**

El código que resolveria el problema sería el siguiente:

```c#
namespace Principio4Interfaces
{
    interface IDeveloperFunction {
        void develop();
        void addRepository();
    }

    interface ICommonFunction {
        void assistMeetings();
        void register();
    }

    interface IManagerFunction {
        void manager();
        void assingTask();

    }


    class Developer2 : ICommonFunction, IDeveloperFunction
    {
        public void addRepository()
        {
            throw new NotImplementedException();
        }

        public void assistMeetings()
        {
            throw new NotImplementedException();
        }

        public void develop()
        {
            throw new NotImplementedException();
        }

        public void register()
        {
            throw new NotImplementedException();
        }
    }

    class Manager : ICommonFunction, IManagerFunction
    {
        public void assingTask()
        {
            throw new NotImplementedException();
        }

        public void assistMeetings()
        {
            throw new NotImplementedException();
        }

        public void manager()
        {
            throw new NotImplementedException();
        }

        public void register()
        {
            throw new NotImplementedException();
        }
    }


    internal class AdministracionEmpresa2
    {
    }
}
```
Con el código anterior al crear interfaces especializadas
solucionamos que sólo las clases implementen las interfaces que 
le interese y no tenemos que añadir validaciones. 

## Inversión dependencia [return](#proyectos-solid-indice)

Las clases de alto nivel no deberían depender de clases de bajo nivel, ambas deben depender de abstracciones. Además, las abstracciones no deben depender de detalles, sino los detalles de las abstracciones.
<br>Ejemplo: En lugar de que un objeto de una clase de alto nivel dependa directamente de una implementación específica de bajo nivel, debería depender de una interfaz o clase abstracta, permitiendo flexibilidad para cambiar la implementación.

Para entender este concepto usaremos el siguiente escenario

> Supón que tienes una aplicación que envía notificaciones a los usuarios. Inicialmente, podrías tener una clase NotificacionService que depende directamente de una clase concreta como EmailService para enviar correos electrónicos.

**Sin Inversion de dependencias**
```c#
namespace Principio5Inversion
{
    public class EmailService {
        public void SendEmail(string mensaje) {
            Console.WriteLine($"Enviando email: {mensaje}");
        }
    }

    public class NotificationService {
        private EmailService EmailService;

        public NotificationService(EmailService EmailService)
        {
            this.EmailService = EmailService;
        }

        public void EnviarNotificacion(string mensaje) { 
              EmailService.SendEmail( mensaje);
        
        }
    
    }

 
}
```
**Problemas**

- Alta dependencia: NotificacionService depende directamente de EmailService. Si necesitas cambiar la forma de enviar la notificación (por ejemplo, usar un servicio de SMS en lugar de email), tendrás que modificar la clase NotificacionService, lo que rompe el principio de abierto/cerrado (OCP).
<br>

- Dificultad para extender: No puedes agregar fácilmente nuevos tipos de notificaciones sin cambiar el código existente.

**Resolviendo el problema**
Para cumplir con DIP: <br>
Hacemos que ambas clases dependan de una abstracción, en este caso una interfaz. Así, NotificacionService no necesita conocer los detalles de la implementación de envío (Email, SMS, etc.), solo sabe que puede enviar notificaciones a través de cualquier servicio que implemente la interfaz INotificacion.

```c#
namespace Principio5Inversion
{
    public interface INotificationService {
        void Send(string message);
    }

    internal class EmailService2 : INotificationService
    {
        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }

    internal class SMSService : INotificationService
    {
        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }
    public class NotificacionService
    {
        private readonly INotificationService _notificacion;

        // Inyección de dependencias a través del constructor
        public NotificacionService(INotificationService notificacion)
        {
            _notificacion = notificacion;
        }

        public void EnviarNotificacion(string mensaje)
        {
            _notificacion.Send(mensaje);
        }
    }
}
```
