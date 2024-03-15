# Manejo de errores en C#
Como ya vimos la semana pasada, el patrón `Result` nos es muy útil a la hora
de gestionar los errores que suceden en nuestra aplicación. Si bien la semana
pasada vimos lo que podría denominarse una implementación personalizada del
mismo para un caso de uso, la intención de la formación de hoy es ver una
implementación que podamos usar independientemente del caso de uso. Para ello,
primero veremos que son los tipos genéricos y cómo implementarlos ya que tanto
el `Result` genérico como el `Either` se sirven de este mecanismo para su
implementación.

### **Los Tipos Genéricos**
Un tipo genérico no es más que una clase a la cual se le pasa en su instaciación
un tipo con el que hará sus operaciones. Seguro que todas las personas que
programamos hemos visto en algún momento algo del estilo `List<String>` por
ejemplo. Pues que sepan que `List` en este caso es un tipo genérico.

### **`Result` como tipo genérico**
Una implementación del patrón `Result` de manera genérica nos va a permitir
homogeneizar la manera en la que gestionamos nuestros errores y el cómo
devolvemos cosas en los métodos. Tal como comentábamos la semana pasada,
es el paso más cercano a la mónada `Either` sin entrar en programación
funcional (salvo que nuestra implementación haga uso de la misma) y por
tanto, es el paso natural de aquellas personas que quieran acercarse a la
programación funcional de una manera más sencilla

## Ejercicios

### __Ejercicio 1__
Para practicar con los tipos genéricos, vamos a implementar una clase que
represente un valor para luego poder crear nuestra propia implementacion
de una lista de valores. Para ello, vamos a seguir los siguientes pasos:

1. Creamos una interfaz `Value` que represente un valor genérico con un
   metodo `value`.

2. Creamos una clase `StringValue` y `NumberValue` (por no sobreescribir
   la que los lenguajes tienen) para crear nuestros propios valores y
   hacemos que implementen la interfaz `Value`.

3. Creamos una clase `ValueList` que represente una lista de valores. Esta
   clase sera nuestro tipo generico que solo aceptara como parametro un tipo
   que implemente la interfaz `Value`.

4. Creamos los metodos para ValueList que creamos necesarios

### __Ejercicio 2__
Vamos a implementar una clase `Result` que represente un resultado de una
ejecucion. Esto quiere decir que por defecto, el tipo del error sera como
hicimos la semana pasada `Error` (`AppError` en caso de ts) y el tipo que
recibira por parametro, sera el tipo del objeto que queramos devolver en
caso de que todo vaya bien (Ojo cuidao, que este tipo puede no necesitarse
para aquellas ejecuciones que no devuelvan nada).