David Fernando Caceres Mamani

**MEDICION**

**RESULTADOS**

| Tamaño | Ingenua (ms) | Mejorada (ms) | Relación ingenua |
|----------|----------:|----------:|----------:|
| 18 | 98,00 | 0,00 | - |
| 20 | 445,33 | 0,00 | 4,54x |
| 22 | 1980,00 | 0,00 | 4,45x |
| 24 | 5947,67 | 0,00 | 3,00x |

Las pruebas verificaron que ambas soluciones produjeron exactamente la misma ganancia en todos los casos (True en todas las ejecuciones).

**CONCLUSION**

La solución ingenua presenta un crecimiento exponencial. Al aumentar dos paquetes, el tiempo de ejecución aumenta aproximadamente entre 3 y 4,5 veces, comportamiento coherente con una complejidad exponencial O(2^n).

La solución mejorada mantiene tiempos tan bajos que aparecen como 0,00 ms en las mediciones realizadas, mostrando una diferencia muy importante respecto a la solución ingenua.

Las variaciones entre factores de crecimiento se deben al ruido de medición producido por el sistema operativo, procesos en segundo plano y la precisión del reloj utilizado.

**MEDICION CON 1000 PAQUETES**

Capacidad calculada automáticamente por EjecutarCarga.

Tiempo obtenido:

231 ms

**CAPACIDAD DE 1000000000 KG**

La solución implementada utiliza programación dinámica con complejidad O(n × capacidad).

Si la capacidad aumentara a 1.000.000.000 kg, la tabla de programación dinámica sería extremadamente grande y requeriría una cantidad de memoria impracticable. Además, el tiempo de ejecución crecería de forma proporcional a la capacidad.

Por esta razón, aunque la solución es mucho más eficiente que la fuerza bruta, dejaría de ser práctica para capacidades tan grandes.