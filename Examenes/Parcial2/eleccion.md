David Fernando Caceres Mamani


ELECCION ESTRUCTURA

| Operación | Frecuencia en una jornada | Estructura utilizada | Complejidad |
| --- | --- | --- | --- |
| Registrar pedido | Muy alta | PriorityQueue | O(log n) |
| Preparar siguiente pedido | Muy alta | PriorityQueue | O(log n) |
| Consultar si un pedido está pendiente | Alta | HashSet | O(1) |
| Obtener cantidad de pendientes | Alta | PriorityQueue | O(1) |

JUSTIFICACION

Se eligió una PriorityQueue porque permite obtener siempre el pedido más urgente sin recorrer todos los pedidos pendientes. La prioridad se define por el plazo y, en caso de empate, por el orden de llegada.

Además, se utiliza un HashSet para responder rápidamente a las consultas de pedidos pendientes, evitando búsquedas secuenciales.

PORQUE NO SIRVE UNA LISTA SIMPLE ?

Con una lista simple, cada vez que se prepara un pedido es necesario recorrer todos los elementos para encontrar el de menor plazo. Esto provoca un costo O(n) por preparación.

Para n = 120.000 pedidos:

Lista simple: 120.000 × 120.000 ≈ 14.400.000.000 operaciones

PriorityQueue: 120.000 × log₂(120.000) ≈ 120.000 × 17 ≈ 2.040.000 operaciones

La diferencia es muy significativa, especialmente para jornadas con gran cantidad de pedidos.

CUANDO CAMBIARIA DE OPINION ?

Si la cantidad de pedidos fuera muy pequeña o las operaciones de preparación fueran poco frecuentes, una lista simple podría ser suficiente debido a su sencillez. También consideraría otra estructura si las búsquedas por nombre fueran mucho más frecuentes que la gestión de prioridades.

