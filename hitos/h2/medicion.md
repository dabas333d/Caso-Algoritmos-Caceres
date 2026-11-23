MEDICION EXPERIMIENTAL

PROBLEMA

Búsqueda de computadoras mediante código de inventario dentro de un sistema de gestión de aproximadamente 5000 equipos.

ESTRUCTRUCTURAS COMPARADAS

SOLUCION INGENUA

List utilizando búsqueda secuencial mediante Contains().

SOLUCION ADECUADA

HashSet utilizando búsqueda por tabla hash mediante Contains().

PROTOCOLO

1. Se realizó una ejecución de calentamiento antes de medir.
2. Cada prueba se repitió tres veces.
3. Se calculó el tiempo promedio.
4. Los tamaños de entrada se duplicaron en cada medición.

RESULTADOS

| Tamaño | Lista (ms) | Incremento | HashSet (ms) | Incremento |
| --- | --- | --- | --- | --- |
| 1000 | 0,647 | \- | 0,023 | \- |
| 2000 | 0,991 | x1,53 | 0,013 | x0,57 |
| 4000 | 2,260 | x2,28 | 0,014 | x1,08 |
| 8000 | 7,896 | x3,49 | 0,022 | x1,57 |

CONCLUSION

Los resultados muestran que el tiempo de búsqueda en la lista aumenta conforme crece la cantidad de computadoras almacenadas. Aunque existen pequeñas variaciones debido al ruido del sistema operativo, la memoria y otros procesos en ejecución, la tendencia general coincide con el comportamiento esperado de una complejidad O(n).

Por otro lado, HashSet mantiene tiempos muy bajos y relativamente estables incluso cuando el tamaño de los datos se duplica. Esto coincide con el comportamiento esperado de una estructura hash, cuya búsqueda tiene complejidad promedio O(1).

Para un inventario con miles de computadoras, HashSet resulta más eficiente para realizar búsquedas frecuentes por código de inventario.

