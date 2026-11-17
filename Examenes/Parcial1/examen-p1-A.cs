// PARCIAL 1 · VARIANTE A — "Registro de carnets"
// Problema: dada una lista de carnets, ¿hay alguno repetido?
// La función HayRepetidosPorPares es CORRECTA pero LENTA. Tu trabajo: analizarla, CURARLA (escribir una
// versión que cueste menos), medir las dos y elegir. Puedes usar este archivo tal cual (si tienes .NET)
// o portar todo a TU lenguaje.

using System.Diagnostics;

namespace Parcial1.VarianteA;

public static class Registro
{
    // Solución ACTUAL (lenta): comparar cada carnet con todos los que le siguen.
    public static bool HayRepetidosPorPares(int[] carnets)
    {
        for (int i = 0; i < carnets.Length; i++)
            for (int j = i + 1; j < carnets.Length; j++)
                if (carnets[i] == carnets[j]) return true;
        return false;
    }

    // TU CURA: escribe aquí una versión correcta que cueste MENOS que O(n²).
    // No modifiques la lista que recibes (trabaja sobre una copia si la necesitas ordenada).
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

    // El PEOR CASO para las dos: una lista SIN repetidos (hay que mirarlo todo).
    public static int[] GenerarSinRepetidos(int n, int semilla = 42)
    {
        var datos = new int[n];
        for (int i = 0; i < n; i++) datos[i] = i;
        var azar = new Random(semilla);
        for (int i = n - 1; i > 0; i--)
        {
            int k = azar.Next(i + 1);
            (datos[i], datos[k]) = (datos[k], datos[i]);
        }
        return datos;
    }
}

public static class Programa
{
    // Los cinco casos que tu cura debe pasar (la esperada va a la derecha).
    private static readonly (int[] datos, bool esperado, string que)[] Casos =
    {
        (new[] { 7, 3, 9, 3, 5 },   true,  "repetido en el medio"),
        (new[] { 7, 3, 9, 4, 5 },   false, "sin repetidos"),
        (new int[] { },             false, "lista vacía"),
        (new[] { 8 },               false, "un solo elemento"),
        (new[] { 4, 1, 2, 6, 4 },   true,  "repetido en los extremos"),
    };

    public static void Main()
    {
        foreach (var (datos, esperado, que) in Casos)
        {
            bool lenta = Registro.HayRepetidosPorPares(datos);
            string curada;
            try { curada = Registro.HayRepetidosCurado(datos).ToString(); }
            catch (NotImplementedException) { curada = "(sin escribir)"; }
            Console.WriteLine($"{que,-26} esperado {esperado,-5} · por pares {lenta,-5} · tu cura {curada}");
        }

        // Una medición de ejemplo, SIN protocolo (el protocolo lo agregas tú en tu medición):
        var grande = Registro.GenerarSinRepetidos(5_000);
        var reloj = Stopwatch.StartNew();
        Registro.HayRepetidosPorPares(grande);
        Console.WriteLine($"Por pares con 5.000 datos: {reloj.ElapsedMilliseconds} ms (una sola medición: no es evidencia)");
    }
}
