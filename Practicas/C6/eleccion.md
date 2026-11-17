# Elección para mi caso (inventario de equipos)

Datos : 5000 equipos hoy · 20000 equipos en el peor escenario miles de asignaciones y movimientos por mes

Lo que pesa : buscar un equipo para asignaciones, movimientos y generación de reportes

Candidato A : recorrer la lista uno por uno ............ O(n) por búsqueda

Candidato B : ordenar por código \+ búsqueda binaria .... O(log n) por búsqueda

Elección : B, porque el crecimiento esperado del inventario hará que las busquedas sean cada vez mas frecuntes. Aunque requiere mantener los datos ordenados, la cantidad de comparaciones es mucho menor que en una búsqueda lineal

Evidencia : en la práctica C4, con 1000000 de registros, la búsqueda lineal necesito 1000000 pasos. la búsqueda binaria necesito solamente 20 pasos. Ademas la búsqueda binaria fue aproximadamente 2397 veces más rápida

Como medire : realizar pruebas con 5000, 10000 y 20000 registros. Para cada tamaño se registrará: 
- cantidad de comparaciones 
- tiempo de respuesta 
- comportamiento en el peor caso Los resultados se compararán para verificar el crecimiento O(n) frente al crecimiento O(log n)

