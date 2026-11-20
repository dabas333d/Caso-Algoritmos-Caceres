DISEÑO DE LA MEDICIÓN
1. PROCESO SELECCIONADO

El proceso que se busca optimizar corresponde a la gestión de inventario de equipos tecnológicos asignados a usuarios. Actualmente se realizan búsquedas frecuentes de equipos mediante código de inventario, número de serie o usuario asignado.

    Las operaciones más comunes son:
- Buscar un equipo.
- Registrar un nuevo equipo.
- Actualizar asignaciones.
- Registrar movimientos de transferencia o devolución.
- Generar reportes.
## ¿Necesito orden o solo búsqueda?
Para este caso, la operación predominante es la búsqueda de equipos específicos mediante una clave única (código o número de serie). Aunque los datos pueden mostrarse ordenados en reportes, el principal requerimiento es encontrar registros de manera rápida.

2. ESTRUCTURAS COMPARADAS

### Solución ingenua
Se utilizará una colección tipo:
```csharp
List<Equipo>
```
La búsqueda se realiza recorriendo cada elemento hasta encontrar el registro solicitado.

### Solución adecuada
Se utilizará:
```csharp
SortedSet<Equipo>
```
Esta estructura está implementada mediante un árbol Rojo-Negro (Red-Black Tree), que mantiene el balance automáticamente y evita la degeneración del árbol.

3. COSTOS TEORICOS

| Operación | List | SortedSet |
|------------|------------|------------|
| Buscar | O(n) | O(log n) |
| Insertar | O(1) | O(log n) |
| Eliminar | O(n) | O(log n) |

4. DISEÑO DE EXPERIMENTO

Se comparará el tiempo de búsqueda de equipos utilizando las dos estructuras de datos.

### Implementación ingenua
- Estructura: List<Equipo>
- Método de búsqueda: recorrido secuencial.

### Implementación adecuada
- Estructura: SortedSet<Equipo>
- Método de búsqueda: búsqueda en árbol balanceado.

5. TAMAÑO DE PRUEBA

Se realizarán mediciones con las siguientes cantidades de registros:
- 100 equipos
- 500 equipos
- 1000 equipos
- 2500 equipos
- 5000 equipos
Estos tamaños representan escenarios progresivamente más cercanos al volumen real del inventario administrado.

6. METRICA A REGISTRAR

Se medirá:
- Tiempo de búsqueda.
- Cantidad de registros procesados.
- Comportamiento de la estructura al aumentar el tamaño de los datos.
Las mediciones se realizarán utilizando la clase `Stopwatch` de C#.

7. HIPOTESIS

Se espera que:
- La estructura `List<Equipo>` incremente su tiempo de búsqueda de forma proporcional al crecimiento de los registros.
- La estructura `SortedSet<Equipo>` mantenga tiempos significativamente menores gracias a la complejidad O(log n).
- La diferencia entre ambas soluciones sea más evidente a partir de 1000 registros.
