David Fernando Caceres Mamani

MEDICION

Se utilizó el siguiente protocolo:

- 1 corrida de calentamiento.
- 3 corridas medidas.
- Cálculo del promedio.
- Tamaños utilizados: 10.000, 20.000 y 40.000 pedidos.

ReceptorIngenuo

| Tamaño | Corrida 1 (ms) | Corrida 2 (ms) | Corrida 3 (ms) | Promedio (ms) | Factor |
|---------|---------|---------|---------|---------|---------|
| 10.000 | 4289 | 3755 | 3599 | 3881 | - |
| 20.000 | 11644 | 9144 | 12577 | 11122 | 2,87x |
| 40.000 | 50625 | 54088 | 53522 | 52745 | 4,74x |

ReceptorMejorado

| Tamaño | Corrida 1 (ms) | Corrida 2 (ms) | Corrida 3 (ms) | Promedio (ms) | Factor |
|---------|---------|---------|---------|---------|---------|
| 10.000 | 9 | 17 | 30 | 19 | - |
| 20.000 | 12 | 13 | 22 | 16 | 0,84x |
| 40.000 | 70 | 190 | 87 | 116 | 7,25x |

CONCLUSIONES

El ReceptorIngenuo presenta un crecimiento acelerado de los tiempos conforme aumenta la cantidad de pedidos. Al duplicar el tamaño de entrada los tiempos aumentan varias veces, lo que es consistente con un comportamiento cercano a O(n²) debido a que cada preparación requiere recorrer la lista para encontrar el pedido de menor plazo.

El ReceptorMejorado obtiene tiempos significativamente menores gracias al uso de una PriorityQueue para gestionar prioridades y un HashSet para las búsquedas de pedidos pendientes. Su rendimiento es muy superior al de la solución ingenua.

Se observa cierta variación entre las corridas, especialmente en los tiempos más pequeños, debido al ruido normal del sistema, procesos en segundo plano y gestión de memoria. Aun así, la diferencia entre ambas soluciones es clara y confirma que la estructura elegida resulta mucho más eficiente para grandes cantidades de pedidos.