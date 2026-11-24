using System.Diagnostics;

namespace H3;

public static class Demo
{
    public static void Comparar()
    {
        Console.WriteLine("H3 - Renovacion de Computadoras");
        Console.WriteLine();

        Console.WriteLine(
            $"{"Equipos",10} {"Dinamica(ms)",15} {"FuerzaBruta(ms)",18} {"Resultado"}");

        foreach (int n in new[] { 10, 12, 14, 16 })
        {
            var equipos = GenerarEquipos(n);

            int presupuesto = n * 10;

            int dinamica = 0;
            int fuerzaBruta = 0;

            double td = Promedio(() =>
                dinamica =
                    RenovacionDinamica
                        .Resolver(
                            equipos,
                            presupuesto));

            double tf = Promedio(() =>
                fuerzaBruta =
                    RenovacionFuerzaBruta
                        .Resolver(
                            equipos,
                            presupuesto));

            Console.WriteLine(
                $"{n,10} {td,15:0.000} {tf,18:0.000} {(dinamica == fuerzaBruta ? "OK" : "ERROR")}");
        }
    }

    private static Computadora[] GenerarEquipos(int cantidad)
    {
        var rnd = new Random(cantidad);

        return Enumerable
            .Range(0, cantidad)
            .Select(_ => new Computadora(
                rnd.Next(5, 20),
                rnd.Next(10, 100)))
            .ToArray();
    }

    private static double Promedio(Action accion)
    {
        accion();

        double suma = 0;

        for (int i = 0; i < 3; i++)
        {
            var sw = Stopwatch.StartNew();

            accion();

            sw.Stop();

            suma += sw.Elapsed.TotalMilliseconds;
        }

        return suma / 3;
    }
}