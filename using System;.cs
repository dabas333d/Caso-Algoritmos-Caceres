using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = 1000000; // 1 millón de elementos
        int[] arreglo = new int[n];

        // Llenar arreglo
        for (int i = 0; i < n; i++)
        {
            arreglo[i] = i;
        }

        int buscado = n - 1; // último elemento

        Stopwatch tiempo = new Stopwatch();

        // BUSQUEDA LINEAL O(n)
        tiempo.Start();

        bool encontrado = false;
        foreach (int numero in arreglo)
        {
            if (numero == buscado)
            {
                encontrado = true;
                break;
            }
        }

        tiempo.Stop();

        Console.WriteLine("Busqueda Lineal");
        Console.WriteLine("Encontrado: " + encontrado);
        Console.WriteLine("Tiempo: " + tiempo.ElapsedMilliseconds + " ms");

        // Reiniciar cronómetro
        tiempo.Reset();

        // BUSQUEDA BINARIA O(log n)
        tiempo.Start();

        int inicio = 0;
        int fin = arreglo.Length - 1;
        int posicion = -1;

        while (inicio <= fin)
        {
            int medio = (inicio + fin) / 2;

            if (arreglo[medio] == buscado)
            {
                posicion = medio;
                break;
            }

            if (arreglo[medio] < buscado)
                inicio = medio + 1;
            else
                fin = medio - 1;
        }

        tiempo.Stop();

        Console.WriteLine("\nBusqueda Binaria");
        Console.WriteLine("Posicion: " + posicion);
        Console.WriteLine("Tiempo: " + tiempo.ElapsedMilliseconds + " ms");
    }
}