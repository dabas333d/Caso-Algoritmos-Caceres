using System.Diagnostics;

namespace H3;

public static class Demo
{
    public static void Comparar()
    {
        Console.WriteLine("H3 - Inventario de Computadoras");
        Console.WriteLine();

        Console.WriteLine(
            $"{"Tamaño",8} {"Voraz (ms)",15} {"Fuerza Bruta (ms)",20}");

        foreach (int n in new[] { 100, 500, 1000, 5000 })
        {
            bool[] inventario = GenerarInventario(n);

            double tv = Medir(() =>
                InventarioVoraz.BuscarDisponible(inventario));

            double tf = Medir(() =>
                InventarioFuerzaBruta.BuscarDisponible(inventario));

            Console.WriteLine(
                $"{n,8} {tv,15:0.000} {tf,20:0.000}");
        }
    }

    private static bool[] GenerarInventario(int cantidad)
    {
        bool[] equipos = new bool[cantidad];

        for (int i = 0; i < cantidad; i++)
            equipos[i] = false;

        equipos[0] = true;

        return equipos;
    }

    private static double Medir(Action accion)
    {
        var sw = Stopwatch.StartNew();

        accion();

        sw.Stop();

        return sw.Elapsed.TotalMilliseconds;
    }
}
