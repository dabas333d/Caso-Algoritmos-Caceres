ESTRUCTURA SELECCIONADA

ESTRUCTURA ELEGIDA

Para el inventario de computadoras se seleccionó un árbol balanceado implementado mediante SortedDictionary en C\#.

Esta estructura mantiene los elementos ordenados automáticamente y permite realizar búsquedas eficientes.

COSTOS DE LAS OPERACIONES

| Operación | Complejidad |
| --- | --- |
| Buscar por clave | O(log n) |
| Insertar | O(log n) |
| Eliminar | O(log n) |
| Obtener siguiente | O(log n) |
| Consulta por rango | O(log n \+ k) |
| Recorrido ordenado | O(n) |

JUSTIFICACION

La mayoría de las operaciones del sistema requieren localizar computadoras por código de inventario y mantener los registros ordenados.

Un árbol balanceado evita la degradación que puede ocurrir en estructuras lineales y permite mantener costos logarítmicos incluso cuando el inventario contiene miles de equipos.

Por esta razón resulta más adecuado que una lista secuencial para este caso de estudio.

