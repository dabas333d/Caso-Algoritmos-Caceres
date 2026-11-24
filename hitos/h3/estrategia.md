ESTRATEGIA DEL CASO

CASO DEL ESTUDIO

**Sistema de gestión de inventario de computadoras.**

La organización administra aproximadamente 5000 equipos informáticos entre computadoras de escritorio y portátiles. El sistema registra asignaciones, movimientos y disponibilidad de cada equipo.


PROBLEMA DE OPTIMIZACION

Cuando un usuario solicita una computadora, el sistema debe seleccionar un equipo disponible para asignarlo.

El objetivo es realizar la asignación de forma rápida, garantizando además que se aprovechen primero los equipos con mejores condiciones de uso.

ESTRATEGIA ELEGIDA

Algoritmo Voraz (Greedy).

ELECCION VORAZ

La estrategia consiste en seleccionar la mejor computadora disponible según una prioridad previamente definida.

Por ejemplo:

- Mejor estado de mantenimiento.
- Menor antigüedad.
- Mayor rendimiento disponible.

En cada solicitud se elige inmediatamente el equipo con la mejor prioridad sin evaluar todas las posibles asignaciones futuras.

PROPIEDAD DE ELECCION VORAZ

La decisión local consiste en escoger la mejor computadora disponible en ese momento.

Una vez realizada la asignación, ninguna de las demás alternativas disponibles proporciona una mejor asignación para la solicitud actual según el criterio establecido.

Por ello, la mejor decisión local coincide con la mejor decisión para ese paso del problema.

SUBESTRUCTURA VORAZ

Después de asignar una computadora, el problema restante conserva exactamente la misma estructura:

- Existe un conjunto más pequeño de computadoras disponibles.
- Debe atenderse la siguiente solicitud.
- Se aplica nuevamente el mismo criterio de selección.

Por lo tanto, la solución completa se obtiene repitiendo la misma regla sobre problemas cada vez más pequeños.

JUSTIFICACION

No es necesario evaluar todas las combinaciones posibles de asignaciones. Seleccionar directamente la computadora que posee la mayor prioridad produce una solución eficiente y rápida para la operación del sistema.

Esta característica permite que el algoritmo escale adecuadamente incluso cuando el inventario contiene miles de equipos.

CONCLUSION

El problema admite una estrategia voraz porque puede tomarse una decisión local basada en una prioridad claramente definida y el problema restante conserva la misma estructura. Esto permite realizar asignaciones eficientes con bajo costo computacional en inventarios de gran tamaño.
