ESTRATEGIA DEL CASO

CASO DEL ESTUDIO

Sistema de gestión de inventario de computadoras.

La organización administra aproximadamente 5000 equipos informáticos entre computadoras de escritorio y portátiles. El sistema registra asignaciones, movimientos y disponibilidad de cada equipo.

PROBLEMA DE OPTIMIZACION

Cuando un usuario solicita una computadora, el sistema debe seleccionar un equipo disponible para asignarlo.

El objetivo es realizar la asignación de forma rápida y eficiente.

ESTRATEGIA ELEGIDA

Algoritmo voraz (Greedy).

ELECCION VORAZ

La estrategia consiste en seleccionar inmediatamente la primera computadora disponible encontrada en el inventario.

Se toma la mejor decisión local disponible sin analizar todas las alternativas posibles.

BUSESTRATEGIA OPTIMA

Después de asignar una computadora, el problema restante mantiene exactamente la misma estructura: buscar la siguiente computadora disponible para futuras solicitudes.

Por esta razón, el problema puede resolverse repitiendo el mismo criterio en cada paso.

JUSTIFICACION

Para este escenario no es necesario evaluar todas las combinaciones posibles de equipos. Encontrar la primera computadora disponible satisface correctamente la solicitud y reduce el tiempo de procesamiento.

CONCLUSION

El problema admite una estrategia voraz porque cada decisión puede tomarse localmente y el problema restante conserva la misma estructura. Esta estrategia permite realizar asignaciones rápidas incluso cuando el inventario contiene miles de equipos.

