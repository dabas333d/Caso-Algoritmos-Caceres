// CLASE 6 · RECURRENCIAS — cómo se calcula el costo de algo que se llama a sí mismo
// Todo lo que imprime este programa es EXACTO (conteos): sale igual en cualquier computadora.
// No hay milisegundos: la clase de hoy es sobre la FORMA del costo, no sobre el reloj.

namespace C6.Recurrencias;

public static class Demo
{
    // ---------- PARTE A · DOS RECURSIONES, DOS COSTOS MUY DISTINTOS ----------
    private static long _llamadas;

    private static long Suma(int n)           // T(n) = T(n-1) + 1   -> n llamadas
    {
        _llamadas++;
        if (n == 0) return 0;
        return n + Suma(n - 1);
    }

    private static long Fib(int n)            // T(n) = T(n-1) + T(n-2) + 1   -> crece como 1.6^n
    {
        _llamadas++;
        if (n < 2) return n;
        return Fib(n - 1) + Fib(n - 2);
    }

    public static void Llamadas()
    {
        Console.WriteLine("PARTE A · CUÁNTAS VECES SE LLAMA A SÍ MISMA");
        Console.WriteLine("Suma(n): una llamada por cada n  ->  T(n) = T(n-1) + 1  ->  O(n)");
        Console.WriteLine("Fib(n):  cada llamada abre DOS    ->  T(n) = T(n-1) + T(n-2) + 1  ->  exponencial");
        Console.WriteLine();
        Console.WriteLine($"{"n",4} {"llamadas Suma",15} {"llamadas Fib",15} {"Fib: x respecto a n-5",24}");
        long previa = 0;
        foreach (int n in new[] { 5, 10, 15, 20, 25, 30, 35 })
        {
            _llamadas = 0; Suma(n); long ls = _llamadas;
            _llamadas = 0; Fib(n); long lf = _llamadas;
            string x = previa == 0 ? "—" : $"x{(double)lf / previa:0.00}";
            Console.WriteLine($"{n,4} {ls,15:N0} {lf,15:N0} {x,24}");
            previa = lf;
        }
        Console.WriteLine();
        Console.WriteLine("Cada 5 más en n, Fib hace ~11 veces más llamadas (1.618 elevado a 5). Suma solo crece de a 5.");
        Console.WriteLine("Con n = 50, Fib haría unos 40 mil millones de llamadas. Las recurrencias son la forma de saberlo ANTES de correrlo.");
    }

    // ---------- PARTE B · EL ÁRBOL DE RECURSIÓN, NIVEL POR NIVEL ----------
    private static long[] _trabajoPorNivel = new long[0];

    private static void Mezclar(int[] a, int[] tmp, int ini, int fin, int nivel)
    {
        if (ini >= fin) return;
        int medio = ini + (fin - ini) / 2;
        Mezclar(a, tmp, ini, medio, nivel + 1);
        Mezclar(a, tmp, medio + 1, fin, nivel + 1);
        int i = ini, j = medio + 1, k = ini;
        while (i <= medio && j <= fin) tmp[k++] = a[i] <= a[j] ? a[i++] : a[j++];
        while (i <= medio) tmp[k++] = a[i++];
        while (j <= fin) tmp[k++] = a[j++];
        for (k = ini; k <= fin; k++) a[k] = tmp[k];
        _trabajoPorNivel[nivel] += fin - ini + 1;     // este nivel mezcló (fin-ini+1) datos
    }

    private static int PasosBinaria(int[] ordenado, int buscado)
    {
        int ini = 0, fin = ordenado.Length - 1, pasos = 0;
        while (ini <= fin)
        {
            pasos++;
            int m = ini + (fin - ini) / 2;
            if (ordenado[m] == buscado) return pasos;
            if (ordenado[m] < buscado) ini = m + 1; else fin = m - 1;
        }
        return pasos;
    }

    public static void Niveles()
    {
        Console.WriteLine("PARTE B · EL ÁRBOL DE MERGESORT CON 1.024 DATOS");
        Console.WriteLine("T(n) = 2 T(n/2) + n   (dos mitades, y mezclar cuesta n)");
        Console.WriteLine();
        const int n = 1024;
        var rnd = new Random(7);
        var datos = new int[n];
        for (int i = 0; i < n; i++) datos[i] = rnd.Next(100000);
        _trabajoPorNivel = new long[16];
        Mezclar(datos, new int[n], 0, n - 1, 0);
        Console.WriteLine($"{"nivel",5} {"subproblemas",13} {"tamaño c/u",11} {"trabajo del nivel (medido)",28} {"acumulado",10}");
        long acumulado = 0;
        for (int nivel = 0; nivel < 10; nivel++)
        {
            acumulado += _trabajoPorNivel[nivel];
            Console.WriteLine($"{nivel,5} {1 << nivel,13} {n >> nivel,11} {_trabajoPorNivel[nivel],28} {acumulado,10:N0}");
        }
        Console.WriteLine();
        Console.WriteLine($"10 niveles (log2 1024) x 1.024 de trabajo por nivel = {10 * n:N0} = n log n.");
        Console.WriteLine();
        Console.WriteLine("LA BINARIA ES T(n) = T(n/2) + 1 : un paso por nivel, un solo subproblema por nivel");
        Console.WriteLine($"{"n",12} {"pasos (peor caso)",18} {"log2 n + 1",11}");
        foreach (int tam in new[] { 1_000, 100_000, 1_000_000, 16_000_000 })
        {
            var ord = new int[tam];
            for (int i = 0; i < tam; i++) ord[i] = i * 2;
            int pasos = PasosBinaria(ord, tam * 2 + 1);       // un valor que NO está: el peor caso
            Console.WriteLine($"{tam,12:N0} {pasos,18} {Math.Floor(Math.Log2(tam)) + 1,11}");
        }
    }

    // ---------- PARTE C · EL TEOREMA MAESTRO DE BOLSILLO, COMPROBADO CON NÚMEROS ----------
    // T(n) = a T(n/b) + n^d      (a: cuántos subproblemas · b: cuánto se achica · d: el trabajo de combinar)
    private static double Evaluar(double a, double b, double d, double n)
    {
        if (n <= 1) return 1;
        return a * Evaluar(a, b, d, n / b) + Math.Pow(n, d);
    }

    private static string Forma(double a, double b, double d)
    {
        double bd = Math.Pow(b, d);
        if (Math.Abs(a - bd) < 1e-9) return d == 0 ? "log n" : d == 1 ? "n log n" : $"n^{d} log n";
        if (a < bd) return d == 1 ? "n" : $"n^{d}";
        double exp = Math.Log(a, b);
        return Math.Abs(exp - 1) < 1e-9 ? "n" : $"n^{exp:0.###}";
    }

    private static double Prediccion(double a, double b, double d, double n)
    {
        double bd = Math.Pow(b, d);
        if (Math.Abs(a - bd) < 1e-9) return Math.Pow(n, d) * Math.Log(n, b);
        if (a < bd) return Math.Pow(n, d);
        return Math.Pow(n, Math.Log(a, b));
    }

    public static void Maestro()
    {
        Console.WriteLine("PARTE C · EL TEOREMA MAESTRO DE BOLSILLO:  T(n) = a T(n/b) + n^d");
        Console.WriteLine("  compara  a  con  b^d :   a < b^d  ->  n^d    |   a = b^d  ->  n^d log n   |   a > b^d  ->  n^(log_b a)");
        Console.WriteLine();
        var casos = new (string quien, double a, double b, double d)[]
        {
            ("Búsqueda binaria",            1, 2, 0),
            ("MergeSort",                   2, 2, 1),
            ("Recorrer un árbol completo",  2, 2, 0),
            ("Una mitad, pero se mezcla n", 1, 2, 1),
            ("Cuatro mitades y mezclar n",  4, 2, 1),
            ("Tres mitades y mezclar n",    3, 2, 1),
        };
        Console.WriteLine($"{"recurrencia",-29} {"a",2} {"b",2} {"d",2} {"b^d",4}  {"forma",-10} {"T/predicción: n=2^10",21} {"2^15",8} {"2^20",8}");
        foreach (var c in casos)
        {
            string r = "";
            foreach (int k in new[] { 10, 15, 20 })
            {
                double n = Math.Pow(2, k);
                double cociente = Evaluar(c.a, c.b, c.d, n) / Prediccion(c.a, c.b, c.d, n);
                r += (k == 10 ? $"{cociente,21:0.00}" : $"{cociente,9:0.00}");
            }
            Console.WriteLine($"{c.quien,-29} {c.a,2} {c.b,2} {c.d,2} {Math.Pow(c.b, c.d),4}  {Forma(c.a, c.b, c.d),-10}{r}");
        }
        Console.WriteLine();
        Console.WriteLine("Si el cociente se queda en una constante cuando n crece, la forma predicha es la correcta.");
        Console.WriteLine("(En los casos con log n el cociente baja despacio hacia su constante: el +1 del caso base pesa menos y menos.)");
    }

    public static void Correr()
    {
        Llamadas();
        Console.WriteLine();
        Console.WriteLine(new string('=', 100));
        Niveles();
        Console.WriteLine();
        Console.WriteLine(new string('=', 100));
        Maestro();
    }
}
