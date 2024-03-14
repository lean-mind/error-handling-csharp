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
