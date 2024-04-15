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

### **Métodos de factoría**
Son métodos que usamos para construir objetos, de una manera concreta, y así 
mantener que los constructores no lancen excepciones y solo asignen valores 
a las propiedades y también poder devolver errores en caso de que por ejemplo, 
una validación de un dato del objeto que vamos a construir falle. Suelen ser 
métodos estáticos ya que en el momento en el que se usan, la instancia del 
objeto no está creada todavía.

```java
// Constructor
User aUser = new User("admin", "weekPassword")

// Método de factoria
Result<User> aUser = User.create("admin", "weekPassword")
```

### **Paso de funciones como parámetro**
Dentro del mundo de la programación funcional (nuestra mónada `Either` está 
dentro de este paradigma) lo habitual como su nombre indica es trabajar con 
funciones, y una de las cosas comunes que se suele hacer es recibir funciones 
por parámetro o tener funciones que a su vez devuelven funciones.

Esto es importante tenerlo claro ya que todas las operaciones que se le pueden 
aplicar al `Either` usan el paso de funciones en sus métodos y por tanto es 
algo con lo que si usamos el

usan el paso de funciones en sus métodos y por tanto es algo con lo que si 
usamos el `Either` o cualquier otra mónada.

Dentro del mundo de la programación funcional (nuestra mónada `Either` está 
dentro de este paradigma) lo habitual como su nombre indica es trabajar con 
funciones, y una de las cosas comunes que se suele hacer es recibir funciones 
por parámetro o tener funciones que a su vez devuelven funciones.

Esto es importante tenerlo claro ya que todas las operaciones que se le 
pueden aplicar al `Either` usan el paso de funciones en sus métodos y por 
tanto es algo con lo que si usamos el `Either` o cualquier otra mónada.

### **Mónada `Either`**
El tipo `Either` es un tipo propio de la programación funcional que se usa
para concretar si una ejecución (método, proceso) ha sido exitosa (por tanto
tendrá valor en el `right`) o ha sucedido algún error (por tanto tendrá valor
en el `left`).

Una característica de las mónadas es que no exponen el valor que envuelven
directamente sino que tenemos que acceder a ellos a través de los operadores
funcionales que implementan, a conocer:
- Map: Permite transformar los valores envueltos. `map` para `right` y `mapLeft` 
para `left` aplicando la función de transformación y volviendo a envolver de 
nuevo en un `Either` pero con el nuevo tipo que hemos transformado
- FlatMap o Bind: Permite concatenar metodos que devuelven un `Either`, de tal
manera que evitamos anidamientos de Either
- Fold o Match: Permite desenvolver el valor recibiendo dos funciones (ambas
deben devolver el mismo tipo de dato para que el tipado sea consistente). Una 
de las funciones recibe el valor que tiene la instancia del `Either` en `right`
y la otra función recibe el valor que tiene en `left`.


## Ejercicios
### __Ejercicio 1__
Para practicar con los tipos genéricos, vamos a implementar una clase que
represente un valor para luego poder crear nuestra propia implementación
de una lista de valores. Para ello, vamos a seguir los siguientes pasos:

1. Creamos una interfaz `Value` que represente un valor genérico con un
   método `value`.

2. Creamos una clase `StringValue` y `NumberValue` (por no sobreescribir
   la que los lenguajes tienen) para crear nuestros propios valores y
   hacemos que implementen la interfaz `Value`.

3. Creamos una clase `ValueList` que represente una lista de valores. Esta
   clase sera nuestro tipo genérico que sólo aceptará como parámetro un tipo
   que implemente la interfaz `Value`.

4. Creamos los métodos para ValueList que creamos necesarios

### __Ejercicio 2__
Vamos a implementar una clase `Result` que represente un resultado de una
ejecucion. Esto quiere decir que por defecto, el tipo del error sera como
hicimos la semana pasada `Error` (`AppError` en caso de ts) y el tipo que
recibira por parametro, sera el tipo del objeto que queramos devolver en
caso de que todo vaya bien (Ojo cuidao, que este tipo puede no necesitarse
para aquellas ejecuciones que no devuelvan nada).

### __Ejercicio 3__
Si nos vamos a la clase `User` veremos que su constructor tiene validaciones
y que en base a dichas validaciones se lanzan excepciones. 

1. Cambiar la forma de construccion de `User` para que sea construido a partir 
de un método de factoría y que dicho método de factoría devuelva un `Result<User>`. 

2. Si te da tiempo, haz que todo el código compile haciendo los cambios necesarios

### __Ejercicio 4__
Para practicar sobre paso de funciones como parámetro haremos los siguientes
ejercicios:

1. A un array de números (1,2,3,4,5,6,7,8,9,10), vamos a filtrarlos usando `filter`
pero la función que le pasemos debe ser una función que tenga nombre, es decir,
no puede ser anonima (hacer varios filtros - mayor que X número - pares - impares).
2. Implementamos una función que reciba dos números, y que el resultado de la 
suma, lo muestre por consola. Ojo, que el mostrar por consola, será otra función
que le pasaremos desde fuera para que imprima (a modo de inyección de dependencias)

#### __Ejercicio 4.1__
Currying (alias: currificación). Para el ejercicio de los filtros, hacer:

1. Una función, que reciba como parámetro un número y devuelva una función que 
indique si el número que recibe por parámetro (la segunda función) es mayor 
al número que recibe la primera función. Llamar a la función `isGreaterThan`.
2. ¿Alguna idea más que se te ocurra de este estilo?

### __Ejercicio 5__
¡Hemos llegado al Either! Cogemos la solución al ejercicio 2, es decir, partiremos
de la clase `Result` y le haremos las siguiente modificaciones:

1. Quitamos los métodos de comprobación de `isSuccess` y demás métodos que expongan
información hacia el exterior.
2. Añadimos el tipo de error que tendremos como `left` y el método de factoría
correspondiente para crear un `Either` de tipo `left`.
3. Creamos los métodos de instancia `map` y `mapLeft`.  

   - Método `map`: Recibe una función que, recibe el tipo que tenga el `Either`
   sobre el que estamos operando en el `right` y dicha función, devuelve un tipo nuevo.
   A su vez, este método devuelve una nueva instancia de `Either` cuyo `left` es el
   mismo que ya tenía el `Either` sobre el que operamos, y cuyo `right` es el resultado
   de la función que recibimos.
   
   - Método `mapLeft`: Recibe una función que, recibe el tipo que tenga el `Either`
   sobre el que estamos operando en el `left` y dicha función, devuelve un tipo nuevo.
   A su vez, este método devuelve una nueva instancia de `Either` cuyo `right` es el
   mismo que ya tenía el `Either` sobre el que operamos, y cuyo `left` es el resultado
   de la función que recibimos.

4. Creamos los métodos de instancia `flatMap` y `flatMapLeft`. 
   - Método `flatMap`: Recibe una función que, recibe el tipo que tenga el `Either`
   sobre el que estamos operando en el `right` y dicha función, devuelve un nuevo `Either`.
   Aclarar que esta función no tiene por qué mantener el tipo de los posibles valores sobre
   los que estamos operando ya que justamente, tenemos la opción de cambiarlos.

   - Método `flatMapLeft`: Recibe una función que, recibe el tipo que tenga el `Either`
   sobre el que estamos operando en el `right` y dicha función, devuelve un nuevo `Either`.
   Aclarar que esta función no tiene por qué mantener el tipo de los posibles valores sobre
   los que estamos operando ya que justamente, tenemos la opción de cambiarlos.

5. Creamos el método de instancia `fold`.
   - Método `fold`: Recibe dos funciones. La primera recibe el tipo que tenga el `Either`
   sobre el que estamos operando en el `right` y dicha función, devuelve un tipo nuevo. La 
   segunda recibe el tipo que tenga el `Either` sobre el que estamos operando en el `left` 
   y dicha función, devuelve un tipo nuevo. Recordar que el tipo que devuelven ambas 
   funciones debe ser el mismo.
