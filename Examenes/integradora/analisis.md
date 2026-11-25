David fernando Caceres Mamani

**ANALISIS**

**a) COSTO O DE ""PlanificadorIngenuo.Elegir"" Y PORQUE**

La solución PlanificadorIngenuo prueba todos los subconjuntos posibles de paquetes.

Si existen n paquetes, cada paquete tiene dos posibilidades:

- Llevarlo.
- No llevarlo.

Por lo tanto, existen 2^n combinaciones posibles.

Además, para cada combinación se recorren los n paquetes con el fin de calcular el peso total y la ganancia obtenida.

El costo total es:

O(n · 2^n)

Por esta razón el algoritmo es correcto, pero se vuelve muy lento cuando aumenta la cantidad de paquetes.

**RECURRENCIA T(n)=2T(n−1)+1**

La versión recursiva genera dos llamadas para cada paquete:

- Llevar el paquete actual.
- No llevar el paquete actual.

Por ello cumple la recurrencia:

T(n)=2T(n−1)+1

El teorema maestro de bolsillo NO se aplica porque exige una recurrencia de la forma:

T(n)=aT(n/b)+f(n)

En este caso aparece:

T(n−1)

y no

T(n/b)

Desarrollando la recurrencia:

T(n)=2T(n−1)+1

=2(2T(n−2)+1)+1

=4T(n−2)+3

=8T(n−3)+7

...

=T(0)·2^n+(2^n−1)

Por lo tanto:

T(n)=O(2^n)

La complejidad es exponencial.

**C) SIRVE UN ALGORITMO VORAZ POR GANANCIA POR KILOGRAMO?**

No.

El primer caso de prueba es un contraejemplo.

Paquetes:

| Código | Peso | Ganancia | Ganancia/Kg |
|----------|----------|----------|----------|
| P1 | 10 | 60 | 6 |
| P2 | 20 | 100 | 5 |
| P3 | 30 | 120 | 4 |

Capacidad = 50 kg

Si se aplica una estrategia voraz por ganancia por kilogramo:

1. Se elige P1.
2. Se elige P2.

Resultado:

Ganancia = 160

Sin embargo, la solución óptima es:

- P2
- P3

Peso total = 50

Ganancia total = 220

Por lo tanto, la estrategia voraz falla.

**ESTRATEGIA ELEGIDA**

Se utilizó Programación Dinámica.

Se construye una tabla donde:

dp[i,c]

representa la ganancia máxima obtenible utilizando los primeros i paquetes y una capacidad disponible c.

La estrategia funciona porque aparecen subproblemas repetidos, que se resuelven una sola vez y luego se reutilizan.

Complejidad temporal:

O(n · capacidad)


**D) ESTRUCTURA PARA ESTAENELVIAJE**

Para responder rápidamente a miles de consultas se utiliza:

HashSet<string>

Después de calcular la solución óptima, todos los códigos seleccionados se guardan en el HashSet.

La consulta:

Contains(codigo)

tiene costo promedio:

O(1)

Si se utilizara una lista y se recorriera elemento por elemento, el costo sería:

O(n)

Por esta razón HashSet es la mejor opción para implementar EstaEnElViaje.