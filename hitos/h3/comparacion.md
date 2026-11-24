COMPARACION DE ESTRATEGIAS

PROBLEMA DE OPTIMIZACION

Dentro del sistema de inventario de computadoras se plantea el siguiente problema:

Dado un presupuesto limitado para renovación o mantenimiento, seleccionar el conjunto de computadoras que proporcione el mayor beneficio posible sin exceder el presupuesto disponible.

Cada computadora cuenta con:

- Un costo de renovación.
- Un beneficio esperado.

El objetivo es maximizar el beneficio total.

ESTRATEGIAS COMPARADAS

FUERZA BRUTA

La estrategia de fuerza bruta evalúa todas las combinaciones posibles de computadoras.

Para cada subconjunto calcula:

- Costo total.
- Beneficio total.

Finalmente selecciona la combinación con mayor beneficio que respete el presupuesto.

Su complejidad crece exponencialmente.

PROGRAMACION DINAMICA

La programación dinámica evita recalcular soluciones ya obtenidas.

El algoritmo construye una tabla donde cada celda representa la mejor solución posible para una cantidad de computadoras y un presupuesto determinado.

Las soluciones de problemas más grandes se construyen utilizando soluciones de subproblemas previamente calculados.

VERIFICACION

Se verificó que ambas estrategias producen exactamente el mismo resultado para todos los tamaños evaluados.

Resultado verificado: OK en todos los casos.

PROTOCOLO DE MEDICION

Para cada tamaño se aplicó el siguiente procedimiento:

1. Calentamiento previo de la ejecución.
2. Tres ejecuciones consecutivas.
3. Cálculo del tiempo promedio.
4. Comparación utilizando los mismos datos de entrada.

RESULTADOS

| Equipos | Programación Dinámica (ms) | Fuerza Bruta (ms) |
|----------|----------:|----------:|
| 10 | 1.190 | 0.044 |
| 12 | 0.093 | 0.082 |
| 14 | 0.081 | 0.429 |
| 16 | 0.230 | 2.904 |

CONCLUSION

La programación dinámica y la fuerza bruta obtuvieron exactamente la misma solución en todos los casos evaluados.

Para tamaños pequeños las diferencias son poco visibles debido al ruido de medición y al costo fijo de ejecución del entorno.

A medida que aumenta la cantidad de computadoras, el tiempo de fuerza bruta crece rápidamente, mientras que la programación dinámica mantiene un crecimiento mucho más controlado.

Los resultados observados coinciden con la teoría estudiada, donde fuerza bruta presenta crecimiento exponencial y programación dinámica reutiliza soluciones previamente calculadas para reducir el costo computacional.