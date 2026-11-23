using System.Diagnostics;

Console.WriteLine("MEDICION H2 - INVENTARIO DE COMPUTADORAS");
Console.WriteLine();

Console.WriteLine(
    $"{"Tamano",10} {"Lista(ms)",15} {"Hash(ms)",15}");

foreach (int n in new[] { 1000, 2000, 4000, 8000 })
{
    var lista = Enumerable.Range(1, n).ToList();

    var hash = new HashSet<int>(lista);

    var ausentes =
        Enumerable.Range(n + 1, 1000).ToArray();

    double listaTiempo = Promedio(() =>
    {
        foreach (int codigo in ausentes)
            lista.Contains(codigo);
    });

    double hashTiempo = Promedio(() =>
    {
        foreach (int codigo in ausentes)
            hash.Contains(codigo);
    });

    Console.WriteLine(
        $"{n,10} {listaTiempo,15:0.000} {hashTiempo,15:0.000}");
}

static double Promedio(Action accion)
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
