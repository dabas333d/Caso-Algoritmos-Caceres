DAVID FERNANDO CACERES MAMANI
MEDICIÓN
OBJETIVO
Comparar el tiempo de ejecución de la solución original HayRepetidosPorPares con la solución curada HayRepetidosCurado.
La comparación se realizará utilizando listas sin elementos repetidos, ya que este es el peor caso indicado en el programa proporcionado.
DATOS DE ENTRADA
Se utilizará el método:
GenerarSinRepetidos(n)
Este método genera listas de tamaño n sin carnets repetidos.
Se utilizarán diferentes tamaños de entrada para observar cómo cambia el tiempo de ejecución a medida que aumenta n.
PROTOCOLO DE MEDICIÓN
Para realizar la medición se utilizará Stopwatch de C#.
Se medirán por separado:
1.	HayRepetidosPorPares
2.	HayRepetidosCurado
Cada algoritmo será ejecutado con los mismos datos de entrada para cada tamaño n.
La medición se realizará para varios tamaños de entrada y se registrarán los tiempos obtenidos.
RESULTADOS
Tamaño n	Por pares (ms)	Curado (ms)
1.000	POR MEDIR	POR MEDIR
5.000	POR MEDIR	POR MEDIR
10.000	POR MEDIR	POR MEDIR
20.000	POR MEDIR	POR MEDIR
50.000	POR MEDIR	POR MEDIR

ANÁLISIS DE LOS RESULTADOS
Los tiempos obtenidos se analizarán comparando el crecimiento del tiempo de ejecución de ambas soluciones cuando aumenta el tamaño de la entrada.
La solución por pares tiene complejidad O(n²), mientras que la solución curada tiene un costo esperado O(n). Por ello, se espera que la diferencia de tiempo sea cada vez mayor al aumentar el tamaño de la entrada.
Los valores definitivos de esta sección se completarán después de realizar las mediciones en el equipo utilizado.
CONCLUSIÓN
La medición permitirá comprobar experimentalmente la diferencia entre la solución original y la solución curada.
La solución curada busca reducir el costo de O(n²) a O(n) esperado utilizando un HashSet<int>.
