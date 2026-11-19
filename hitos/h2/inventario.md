**CASO: INVENTARIO DE EQUIPOS**

1. DATOS QUE GUARDA EL PROCESO

Actualmente el sistema administra información relacionada con equipos tecnológicos asignados a usuarios dentro de la organización
    
    DATOS PRINCIPALES
   - Código del equipo
   - Tipo de equipo
   - Marca
   - Modelo
   - Número de serie
   - Estado (Activo, Mantenimiento, Baja)
   - Usuario asignado
   - Área o departamento
   - Fecha de asignación
   - Historial de movimientos

    VOLUMEN DE LA INFORMACION
En períodos de alta actividad se manejan aproximadamente:
   - Aproximadamente 5000 equipos registrados
   - Miles de registros de movimientos
   - Cientos de asignaciones y devoluciones
   - Generación frecuente de reportes por usuario, área y estado

2. OPERACIONES QUE REALIZA EL SISTEMA

BUSCAR EQUIPO POR CÓDIGO
    Ejemplo:
       - Buscar EQ-12548
    Objetivo:
       - Encontrar rápidamente un equipo específico.

REGISTRAR NUEVO EQUIPO
    Ejemplo:
       - Insertar nuevo equipo Lenovo
    Objetivo:
       - Agregar un nuevo registro al inventario.

ASIGNAR EQUIPO A USUARIO
    Ejemplo:
       - Asignar laptop a Juan Pérez
    Objetivo:
       - Actualizar la información del propietario actual.

REGISTRAR MOVIMIENTO
    Ejemplo:
       - Equipo pasa de Soporte a Finanzas
    Objetivo:
       - Guardar cambios de ubicación o responsable.

MODIFICAR INFORMACIÓN
    Ejemplo:
       - Cambiar estado a Mantenimiento
    Objetivo:
       - Actualizar datos existentes.

ELIMINAR EQUIPO
    Ejemplo:
       - Dar de baja un equipo
    Objetivo:
       - Retirar equipos del inventario.

GENERAR REPORTES
    Ejemplos:
       - Equipos por usuario
       - Equipos por área
       - Equipos en mantenimiento
       - Equipos dados de baja
    Objetivo:
       - Recorrer todos los registros y agrupar información.

3. OPERACIONES MÁS FRECUENTES

|**OPERACION**	            |**FRECUENCIA**|
|---|---|
|Buscar equipo	            |Muy alta|
|Asignar equipo	            |Muy alta|
|Registrar movimiento	    |Muy alta|
|Generar reportes	        |Alta|
|Modificar equipo	        |Media|
|Insertar equipo	        |Baja|
|Eliminar equipo	        |Baja|

4. ¿QUÉ ESTRUCTURA RESUELVE MEJOR CADA OPERACIÓN?

|**OPERACION**                    |**MEJOR ESTRUCTURA**	          |**COMPLEJIDAD**	    |**COMENTARIO**|
|---|---|---|---|
|Buscar equipo por código	      |Tabla Hash (Dictionary)	      |O(1)	                |Muy rápida|
|Insertar equipo	              |Tabla Hash	                  |O(1)	                |Inserción inmediata|
|Modificar equipo	              |Tabla Hash	                  |O(1)	                |Localización rápida|
|Eliminar equipo	              |Tabla Hash	                  |O(1)	                |Eliminación rápida|
|Recorrer inventario completo	  |Lista/Array	                  |O(n)	                |Necesario para reportes|
|Buscar equipos ordenados	      |Árbol balanceado	              |O(log n)	            |Mantiene orden|
|Buscar por rango	              |Árbol balanceado	              |O(log n)	            |Más eficiente|

5. RELACION ENTRE OPERACIONES Y ESTRUCTURAS
Las operaciones más frecuentes del sistema son la búsqueda de equipos, la asignación de usuarios y el registro de movimientos. Debido a que estas acciones se realizan constantemente durante la jornada laboral, es importante utilizar estructuras que minimicen el tiempo de respuesta.

Las tablas hash permiten acceder a los equipos mediante su código o número de serie en tiempo promedio O(1), lo que las convierte en la opción más eficiente para las consultas diarias. Por otro lado, los historiales de movimientos pueden almacenarse en listas debido a que requieren preservar el orden temporal de los registros.

Cuando se necesitan consultas ordenadas o búsquedas por rangos, las estructuras basadas en árboles balanceados ofrecen mejores resultados gracias a su complejidad O(log n).

6. CONCLUSIÓN
    El proceso de inventario realiza principalmente búsquedas, asignaciones y registros de movimientos sobre aproximadamente 5000 equipos. Debido a que la operación más frecuente es la búsqueda por código, la estructura más conveniente es una tabla hash (Dictionary), ya que permite búsquedas, inserciones y actualizaciones en tiempo O(1). Para consultas ordenadas o búsquedas por rango, una estructura tipo árbol balanceado resulta más eficiente con complejidad O(log n).