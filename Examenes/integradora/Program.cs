// EVALUACIÓN INTEGRADORA · VARIANTE A — "Furgoneta de reparto"
// Caso: una distribuidora tiene una lista de paquetes (cada uno con un peso en kg y una ganancia en Bs) y una furgoneta
// que aguanta una capacidad en kg. Hay que elegir QUÉ paquetes llevar para ganar lo máximo sin pasarse de la capacidad.
// Cada paquete se lleva entero o no se lleva.
// PlanificadorIngenuo es CORRECTO pero LENTO (prueba todas las combinaciones). Tu trabajo: analizarlo, elegir la
// estrategia, APLICARLA en PlanificadorMejorado, medir la diferencia y justificar todo.
// Puedes usar este archivo tal cual (si tienes .NET) o portar todo a TU lenguaje.

using System.Diagnostics;

namespace Integradora.VarianteA;

public sealed record Paquete(string Codigo, int Kg, int Ganancia);

public interface IPlanificador
{
    // Devuelve la ganancia máxima y los códigos de los paquetes elegidos (en cualquier orden).
    (int ganancia, List<string> codigos) Elegir(Paquete[] paquetes, int capacidadKg);

    // Después de Elegir: ¿este paquete va en la furgoneta?
    bool EstaEnElViaje(string codigo);
}

// ---------- SOLUCIÓN INGENUA: prueba todos los subconjuntos (2^n) ----------
public sealed class PlanificadorIngenuo : IPlanificador
{
    private List<string> _elegidos = new();

    public (int ganancia, List<string> codigos) Elegir(Paquete[] paquetes, int capacidadKg)
    {
        int n = paquetes.Length, mejor = 0;
        long mejorMascara = 0;
        for (long mascara = 0; mascara < (1L << n); mascara++)
        {
            int kg = 0, ganancia = 0;
            for (int i = 0; i < n; i++)
                if ((mascara & (1L << i)) != 0) { kg += paquetes[i].Kg; ganancia += paquetes[i].Ganancia; }
            if (kg <= capacidadKg && ganancia > mejor) { mejor = ganancia; mejorMascara = mascara; }
        }
        _elegidos = new List<string>();
        for (int i = 0; i < n; i++) if ((mejorMascara & (1L << i)) != 0) _elegidos.Add(paquetes[i].Codigo);
        return (mejor, new List<string>(_elegidos));
    }

    public bool EstaEnElViaje(string codigo) => _elegidos.Contains(codigo);          // recorre la lista
}

// ---------- TU SOLUCIÓN: elige la estrategia y la(s) estructura(s) y escríbela aquí ----------
public sealed class PlanificadorMejorado : IPlanificador
{
    private readonly HashSet<string> _viaje = new();

    public (int ganancia, List<string> codigos) Elegir(
        Paquete[] paquetes,
        int capacidadKg)
    {
        _viaje.Clear();

        int n = paquetes.Length;

        if (n == 0 || capacidadKg <= 0)
            return (0, new List<string>());

        int[,] dp = new int[n + 1, capacidadKg + 1];

        for (int i = 1; i <= n; i++)
        {
            var paquete = paquetes[i - 1];

            for (int c = 0; c <= capacidadKg; c++)
            {
                if (paquete.Kg > c)
                {
                    dp[i, c] = dp[i - 1, c];
                }
                else
                {
                    dp[i, c] = Math.Max(
                        dp[i - 1, c],
                        paquete.Ganancia +
                        dp[i - 1, c - paquete.Kg]);
                }
            }
        }

        List<string> elegidos = new();

        int capacidadActual = capacidadKg;

        for (int i = n; i > 0; i--)
        {
            if (dp[i, capacidadActual] != dp[i - 1, capacidadActual])
            {
                var paquete = paquetes[i - 1];

                elegidos.Add(paquete.Codigo);

                _viaje.Add(paquete.Codigo);

                capacidadActual -= paquete.Kg;
            }
        }

        return (dp[n, capacidadKg], elegidos);
    }

    public bool EstaEnElViaje(string codigo)
    {
        return _viaje.Contains(codigo);
    }
}

public static class Programa
{
    private static Paquete[] Lote(params (string c, int kg, int g)[] datos) => datos.Select(d => new Paquete(d.c, d.kg, d.g)).ToArray();

    // Los casos de prueba (todos con ÓPTIMO ÚNICO): (paquetes, capacidad, ganancia esperada, códigos esperados).
    private static readonly (string que, Paquete[] paquetes, int capacidad, int esperada, string[] codigos)[] Casos =
    {
        ("el voraz se equivoca", Lote(("P1", 10, 60), ("P2", 20, 100), ("P3", 30, 120)), 50, 220, new[] { "P2", "P3" }),
        ("cuatro paquetes",      Lote(("P1", 2, 3), ("P2", 3, 4), ("P3", 4, 5), ("P4", 5, 6)), 8, 10, new[] { "P2", "P4" }),
        ("capacidad cero",       Lote(("P1", 5, 10), ("P2", 7, 12)), 0, 0, Array.Empty<string>()),
        ("sin paquetes",         Lote(), 30, 0, Array.Empty<string>()),
        ("nada cabe",            Lote(("P1", 40, 90), ("P2", 50, 100)), 30, 0, Array.Empty<string>()),
        ("entran todos",         Lote(("P1", 5, 10), ("P2", 7, 12), ("P3", 3, 4)), 100, 26, new[] { "P1", "P2", "P3" }),
    };

    private static void Probar(string titulo, Func<IPlanificador> fabrica)
    {
        int bien = 0, total = 0;
        try
        {
            foreach (var (que, paquetes, capacidad, esperada, codigos) in Casos)
            {
                var plan = fabrica();
                var (ganancia, elegidos) = plan.Elegir(paquetes, capacidad);
                total++;
                bool ok = ganancia == esperada && elegidos.OrderBy(x => x).SequenceEqual(codigos.OrderBy(x => x));
                if (ok) bien++;
                else Console.WriteLine($"   MAL en «{que}»: esperado {esperada} con [{string.Join(",", codigos)}], obtuvo {ganancia} con [{string.Join(",", elegidos)}]");
            }
            var p = fabrica();
            p.Elegir(Casos[0].paquetes, Casos[0].capacidad);
            total += 2;
            if (p.EstaEnElViaje("P2")) bien++; else Console.WriteLine("   MAL en «EstaEnElViaje(P2)»: esperado True");
            if (!p.EstaEnElViaje("P1")) bien++; else Console.WriteLine("   MAL en «EstaEnElViaje(P1)»: esperado False");
            Console.WriteLine($"{titulo}: {bien} de {total} pruebas correctas");
        }
        catch (NotImplementedException) { Console.WriteLine($"{titulo}: (sin escribir todavía)"); }
    }

    // La CARGA para medir: n paquetes al azar (semilla fija) y una capacidad de un tercio del peso total.
    public static int EjecutarCarga(IPlanificador plan, int n)
    {
        var azar = new Random(n);
        var paquetes = Enumerable.Range(0, n).Select(i => new Paquete("C" + i, azar.Next(5, 60), azar.Next(10, 100))).ToArray();
        int capacidad = paquetes.Sum(p => p.Kg) / 3;
        var (ganancia, _) = plan.Elegir(paquetes, capacidad);
        return ganancia;
    }

    public static void Main()
    {
        Probar("PlanificadorIngenuo ", () => new PlanificadorIngenuo());
        Probar("PlanificadorMejorado", () => new PlanificadorMejorado());

        // Una medición de ejemplo, SIN protocolo (el protocolo lo agregas tú en tu medición):
        int[] tamanos = {18,20,22,24};

foreach (var n in tamanos)
{
    GC.Collect();

    EjecutarCarga(new PlanificadorIngenuo(), n);

    long totalIngenuo = 0;
    long totalMejorado = 0;

    int gananciaIngenua = 0;
    int gananciaMejorada = 0;

    for (int i = 0; i < 3; i++)
    {
        var r1 = Stopwatch.StartNew();
        gananciaIngenua =
            EjecutarCarga(new PlanificadorIngenuo(), n);
        r1.Stop();

        totalIngenuo += r1.ElapsedMilliseconds;

        var r2 = Stopwatch.StartNew();
        gananciaMejorada =
            EjecutarCarga(new PlanificadorMejorado(), n);
        r2.Stop();

        totalMejorado += r2.ElapsedMilliseconds;
    }

    Console.WriteLine(
        $"{n} | " +
        $"{totalIngenuo/3.0:F2} ms | " +
        $"{totalMejorado/3.0:F2} ms | " +
        $"{gananciaIngenua == gananciaMejorada}");
}
var sw = Stopwatch.StartNew();

EjecutarCarga(
    new PlanificadorMejorado(),
    1000);

sw.Stop();

Console.WriteLine(
    $"1000 paquetes: {sw.ElapsedMilliseconds} ms");
    }
}

