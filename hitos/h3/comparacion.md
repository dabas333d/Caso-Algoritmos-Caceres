COMPARACION DE ESTRATEGIAS

PROBLEMA

Asignación de computadoras disponibles dentro de un inventario de aproximadamente 5000 equipos.

ESTRATEGIAS COMPARADAS

FUERZA BRUTA

Recorre completamente el inventario buscando todas las computadoras disponibles antes de seleccionar una.

VORAZ

Selecciona inmediatamente la primera computadora disponible encontrada.

PRTOCOLO

Se realizaron pruebas utilizando inventarios simulados de distintos tamaños.

Ambas estrategias recibieron exactamente los mismos datos de entrada.

Se comparó el resultado obtenido y el costo computacional requerido.

RESULTADOS

| Tamaño del inventario | Fuerza Bruta | Voraz |
|----------------------|--------------|--------|
| 100 equipos | Equipo encontrado | Equipo encontrado |
| 500 equipos | Equipo encontrado | Equipo encontrado |
| 1000 equipos | Equipo encontrado | Equipo encontrado |
| 5000 equipos | Equipo encontrado | Equipo encontrado |

ANALISIS

Ambas estrategias encuentran correctamente una computadora disponible.

Sin embargo, la estrategia voraz detiene la búsqueda tan pronto encuentra una solución válida, mientras que la fuerza bruta analiza una mayor cantidad de elementos.

CONCLUSION

El algoritmo voraz obtiene el mismo resultado funcional con menor esfuerzo computacional, por lo que resulta más adecuado para la gestión de inventario de computadoras.