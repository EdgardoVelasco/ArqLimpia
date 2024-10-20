# Manejo de Errores [indice](README.md)


1. Errores:

En C#, un “error” es un problema detectado por el compilador o en 
tiempo de compilación. Los errores deben corregirse antes de que el 
programa pueda compilarse y ejecutarse. Los errores suelen estar 
relacionados con problemas como:

	•	Errores de sintaxis: Un error en la estructura del código, 
    como un paréntesis o punto y coma faltante.
	•	Errores de tipo: Cuando se intenta usar un tipo incorrecto 
    de dato o realizar operaciones inválidas entre tipos.
	•	Errores de compilación: Problemas que impiden que el compilador 
    convierta el código fuente en un archivo ejecutable.

Manejo Centralizado de Errores

	1.	El middleware ExcepcionMiddleware captura las excepciones en 
    toda la aplicación y devuelve una respuesta JSON con el código de estado 500 y un mensaje de error amigable.
	2.	El servicio TransaccionService lanza excepciones cuando los 
    valores de entrada son inválidos, como cuando el monto es negativo 
    o cuando se intenta retirar más del saldo disponible.

2. Excepciones:

Las excepciones son problemas que ocurren durante la ejecución de un programa, y se manejan de manera diferente. C# utiliza excepciones para indicar que algo ha salido mal en tiempo de ejecución. Las excepciones pueden ser atrapadas y manejadas por el programador usando bloques try-catch. Algunos ejemplos comunes de excepciones son:

	•	NullReferenceException: Intentar acceder a un objeto que es null.
	•	IndexOutOfRangeException: Acceder a un índice fuera de los 
    límites de una matriz o lista.
	•	InvalidOperationException: Intentar realizar una operación 
    inválida en el estado actual del objeto.
	•	FileNotFoundException: El archivo especificado no se encuentra 
    cuando se intenta abrir o leer.


EJECUCIÓN

- dotnet restore
- dotnet run

Pruebas con Postman:

1. Depositar Dinero (POST):

	•	URL: http://localhost:5000/api/transaccion/deposito
	•	Cuerpo (JSON):
            {
                "monto": 1000
            }

2. Retirar Dinero (POST):

	•	URL: http://localhost:5000/api/transaccion/retiro
	•	Cuerpo (JSON):
            {
                "monto": 500
            }

3. Consultar Saldo (GET):

	•	URL: http://localhost:5000/api/transaccion/saldo