DAVID FERNANDO CACERES MAMANI
1 ANALIZAR
A) CUATRO FRAGMENTOS
F1
Costo en el peor caso: O(n)
El ciclo for recorre los n elementos una sola vez y cada iteración realiza una operación de costo constante.
F2
Costo en el peor caso: O(n²)
El ciclo interno compara cada elemento con los elementos que le siguen, realizando aproximadamente n(n-1)/2 comparaciones en el peor caso.
F3
Costo en el peor caso: O(log n)
En cada iteración k se divide entre 2 hasta llegar a 1, por lo que el número de iteraciones es logarítmico.
F4
Costo en el peor caso: O(n log n)
El ciclo externo se ejecuta n veces y, en cada iteración, el ciclo interno multiplica k por 2 hasta alcanzar n, realizando O(log n) iteraciones.
B) DOS RECURRENCIAS
(i) T(n) = 3T(n/2) + n
•	a = 3
•	b = 2
•	d = 1
•	b^d = 2^1 = 2
Comparación:
a > b^d
3 > 2
Por lo tanto:
T(n) = O(n^log₂(3)) ≈ O(n^1.585)
(ii) T(n) = T(n/2) + n²
•	a = 1
•	b = 2
•	d = 2
•	b^d = 2² = 4
Comparación:
a < b^d
1 < 4
Por lo tanto:
T(n) = O(n²)

ANÁLISIS DE LA FUNCIÓN LENTA
La función HayRepetidosPorPares compara cada carnet con todos los carnets que se encuentran después de él.
En el peor caso, cuando la lista no contiene repetidos, debe realizar todas las comparaciones posibles.
El número de comparaciones es:
n(n-1)/2
Por lo tanto, su costo en el peor caso es:
O(n²)
PROPUESTA DE CURA
La función lenta puede mejorarse utilizando un HashSet<int> para almacenar los carnets que ya fueron encontrados.
La estrategia consiste en recorrer la lista una sola vez. Para cada carnet se verifica si ya se encuentra en el conjunto:
•	Si ya existe, significa que está repetido y se retorna true.
•	Si no existe, se agrega al conjunto y se continúa.
•	Si se termina de recorrer la lista sin encontrar repetidos, se retorna false.
La implementación propuesta es:
public static bool HayRepetidosCurado(int[] carnets)
{
    var vistos = new HashSet<int>();

    foreach (int carnet in carnets)
    {
        if (vistos.Contains(carnet))
            return true;

        vistos.Add(carnet);
    }

    return false;
}
El arreglo carnets no se modifica, ya que solamente se recorre y los valores encontrados se almacenan en un HashSet independiente.
En promedio, las operaciones Contains y Add de HashSet tienen costo O(1). Como se recorre la lista una vez, el costo esperado de la solución curada es:
O(n)
Por lo tanto, la mejora es:
Solución lenta: O(n²)
Solución curada: O(n) esperado
