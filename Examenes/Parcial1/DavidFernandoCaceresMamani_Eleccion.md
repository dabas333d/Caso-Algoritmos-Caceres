DAVID FERNANDO CACERES MAMANI
ELEGIR
SITUACIÓN
El hospital tiene 300.000 números de historia clínica y recibe 5.000 consultas durante el día. Como el listado llega desordenado, se deben comparar las tres alternativas propuestas considerando el tiempo de ejecución y la memoria disponible.

OPCIÓN 1: RECORRER EL LISTADO EN CADA CONSULTA
En cada consulta se puede recorrer todo el listado hasta encontrar el número buscado o llegar al final.
En el peor caso:
5.000 × 300.000 = 1.500.000.000 comparaciones
Por lo tanto, el costo total es:
O(q × n)
Esta opción es muy costosa porque se vuelve a recorrer el listado completo para cada una de las 5.000 consultas.
OPCIÓN 2: ORDENAR UNA VEZ CON O(N LOG N) Y USAR BÚSQUEDA BINARIA
Primero se ordenan los 300.000 registros utilizando un algoritmo de complejidad O(n log n).
Después, cada consulta se realiza mediante búsqueda binaria, cuyo costo es:
O(log n)
Para las 5.000 consultas, el costo total es:
O(n log n + q log n)
Esta opción permite aprovechar el ordenamiento para realizar las consultas rápidamente. Además, se puede trabajar sobre el mismo listado ordenado sin duplicarlo.
OPCIÓN 3: ORDENAR UNA VEZ CON UN ALGORITMO CUADRÁTICO Y USAR BÚSQUEDA BINARIA
El problema de esta opción está en el ordenamiento. Un algoritmo cuadrático tiene un costo:
O(n²)
Con 300.000 registros, ordenar mediante un algoritmo cuadrático requiere una cantidad muy grande de operaciones.
Aunque después cada consulta mediante búsqueda binaria tendría un costo O(log n), el costo total sería:
O(n² + q log n)
Por lo tanto, el costo del ordenamiento hace que esta opción sea poco conveniente.
ELECCIÓN
La mejor alternativa es la opción 2: ordenar una vez el listado con un algoritmo O(n log n) y utilizar búsqueda binaria para las 5.000 consultas.
La opción 1 es ineficiente porque puede realizar hasta 1.500 millones de comparaciones en el peor caso. La opción 3 también debe descartarse porque ordenar 300.000 registros con un algoritmo O(n²) resulta demasiado costoso.
La opción 2 ofrece el mejor equilibrio entre tiempo de ejecución y memoria, ya que el listado se ordena una sola vez y posteriormente las consultas se realizan en O(log n) sin necesidad de duplicar el listado.
