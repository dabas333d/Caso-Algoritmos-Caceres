using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("       ANALISIS DE ALGORITMOS - C5");
        Console.WriteLine("==============================================\n");

        int[] cantidades = { 10000, 20000, 40000, 80000 };

        // Arreglos para guardar los resultados
        double[] resultadosBurbuja = new double[cantidades.Length];
        double[] resultadosQuickSort = new double[cantidades.Length];

        // ==========================================
        // EJECUTAR LAS PRUEBAS
        // ==========================================

        for (int i = 0; i < cantidades.Length; i++)
        {
            int cantidad = cantidades[i];

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Cantidad de elementos: {cantidad}");
            Console.WriteLine("----------------------------------------------");

            // Generar datos
            int[] datos = GenerarDatos(cantidad);

            // ======================================
            // CALENTAMIENTO
            // ======================================

            Console.WriteLine("Calentando...");

            int[] calentamientoBurbuja = (int[])datos.Clone();
            BubbleSort(calentamientoBurbuja);

            int[] calentamientoQuickSort = (int[])datos.Clone();
            QuickSort(
                calentamientoQuickSort,
                0,
                calentamientoQuickSort.Length - 1);

            // ======================================
            // MEDIR BURBUJA
            // ======================================

            double promedioBurbuja = MedirBurbuja(datos);

            resultadosBurbuja[i] = promedioBurbuja;

            // ======================================
            // MEDIR QUICKSORT
            // ======================================

            double promedioQuickSort = MedirQuickSort(datos);

            resultadosQuickSort[i] = promedioQuickSort;

            Console.WriteLine();
        }

        // ==========================================
        // TABLA FINAL
        // ==========================================

        MostrarTabla(
            cantidades,
            resultadosBurbuja,
            resultadosQuickSort);
    }

    // =============================================
    // GENERAR DATOS
    // =============================================

    static int[] GenerarDatos(int cantidad)
    {
        Random aleatorio = new Random(12345);

        int[] datos = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            datos[i] = aleatorio.Next(1, 1000000);
        }

        return datos;
    }

    // =============================================
    // MEDIR BURBUJA
    // =============================================

    static double MedirBurbuja(int[] datos)
    {
        double suma = 0;

        for (int corrida = 1; corrida <= 3; corrida++)
        {
            int[] copia = (int[])datos.Clone();

            Stopwatch reloj = Stopwatch.StartNew();

            BubbleSort(copia);

            reloj.Stop();

            double tiempo = reloj.Elapsed.TotalMilliseconds;

            Console.WriteLine(
                $"Burbuja - Corrida {corrida}: {tiempo:F2} ms");

            if (!EstaOrdenado(copia))
            {
                Console.WriteLine(
                    "ERROR: Burbuja no ordenó correctamente.");
            }

            suma += tiempo;
        }

        double promedio = suma / 3;

        Console.WriteLine(
            $"Burbuja - Promedio: {promedio:F2} ms");

        return promedio;
    }

    // =============================================
    // MEDIR QUICKSORT
    // =============================================

    static double MedirQuickSort(int[] datos)
    {
        double suma = 0;

        for (int corrida = 1; corrida <= 3; corrida++)
        {
            int[] copia = (int[])datos.Clone();

            Stopwatch reloj = Stopwatch.StartNew();

            QuickSort(
                copia,
                0,
                copia.Length - 1);

            reloj.Stop();

            double tiempo = reloj.Elapsed.TotalMilliseconds;

            Console.WriteLine(
                $"QuickSort - Corrida {corrida}: {tiempo:F2} ms");

            if (!EstaOrdenado(copia))
            {
                Console.WriteLine(
                    "ERROR: QuickSort no ordenó correctamente.");
            }

            suma += tiempo;
        }

        double promedio = suma / 3;

        Console.WriteLine(
            $"QuickSort - Promedio: {promedio:F2} ms");

        return promedio;
    }

    // =============================================
    // MOSTRAR TABLA FINAL
    // =============================================

    static void MostrarTabla(
        int[] cantidades,
        double[] burbuja,
        double[] quickSort)
    {
        Console.WriteLine();
        Console.WriteLine("==============================================================");
        Console.WriteLine("                    TABLA DE TIEMPOS");
        Console.WriteLine("==============================================================");

        Console.WriteLine(
            "{0,-15} {1,-20} {2,-20}",
            "Elementos",
            "Burbuja (ms)",
            "QuickSort (ms)");

        Console.WriteLine(
            "--------------------------------------------------------------");

        for (int i = 0; i < cantidades.Length; i++)
        {
            Console.WriteLine(
                "{0,-15} {1,-20:F2} {2,-20:F2}",
                cantidades[i],
                burbuja[i],
                quickSort[i]);
        }

        Console.WriteLine(
            "==============================================================");
    }

    // =============================================
    // BURBUJA
    // =============================================

    static void BubbleSort(int[] arreglo)
    {
        int n = arreglo.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arreglo[j] > arreglo[j + 1])
                {
                    int temporal = arreglo[j];

                    arreglo[j] = arreglo[j + 1];

                    arreglo[j + 1] = temporal;
                }
            }
        }
    }

    // =============================================
    // QUICKSORT
    // =============================================

    static void QuickSort(
        int[] arreglo,
        int izquierda,
        int derecha)
    {
        if (izquierda < derecha)
        {
            int posicionPivote =
                Particionar(
                    arreglo,
                    izquierda,
                    derecha);

            QuickSort(
                arreglo,
                izquierda,
                posicionPivote - 1);

            QuickSort(
                arreglo,
                posicionPivote + 1,
                derecha);
        }
    }

    // =============================================
    // PARTICIONAR
    // =============================================

    static int Particionar(
        int[] arreglo,
        int izquierda,
        int derecha)
    {
        int pivote = arreglo[derecha];

        int i = izquierda - 1;

        for (int j = izquierda; j < derecha; j++)
        {
            if (arreglo[j] <= pivote)
            {
                i++;

                int temporal = arreglo[i];

                arreglo[i] = arreglo[j];

                arreglo[j] = temporal;
            }
        }

        int temporal2 = arreglo[i + 1];

        arreglo[i + 1] = arreglo[derecha];

        arreglo[derecha] = temporal2;

        return i + 1;
    }

    // =============================================
    // VERIFICAR ORDEN
    // =============================================

    static bool EstaOrdenado(int[] arreglo)
    {
        for (int i = 0;
             i < arreglo.Length - 1;
             i++)
        {
            if (arreglo[i] > arreglo[i + 1])
            {
                return false;
            }
        }

        return true;
    }
}