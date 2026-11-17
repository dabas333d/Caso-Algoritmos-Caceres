int n = 5_000;

Console.WriteLine();
Console.WriteLine("MEDICIÓN");
Console.WriteLine("---------------------------------------------");

int[] datos = Registro.GenerarSinRepetidos(n);

// CALENTAMIENTO
Registro.HayRepetidosPorPares(datos);
Registro.HayRepetidosCurado(datos);

// 3 mediciones POR PARES
long totalPares = 0;

for (int i = 0; i < 3; i++)
{
    Stopwatch reloj = Stopwatch.StartNew();

    Registro.HayRepetidosPorPares(datos);

    reloj.Stop();

    Console.WriteLine($"Por pares - corrida {i + 1}: {reloj.ElapsedMilliseconds} ms");

    totalPares += reloj.ElapsedMilliseconds;
}

double promedioPares = totalPares / 3.0;

// 3 mediciones CURA
long totalCura = 0;

for (int i = 0; i < 3; i++)
{
    Stopwatch reloj = Stopwatch.StartNew();

    Registro.HayRepetidosCurado(datos);

    reloj.Stop();

    Console.WriteLine($"Cura      - corrida {i + 1}: {reloj.ElapsedMilliseconds} ms");

    totalCura += reloj.ElapsedMilliseconds;
}

double promedioCura = totalCura / 3.0;

Console.WriteLine("---------------------------------------------");
Console.WriteLine($"Promedio por pares: {promedioPares:F2} ms");
Console.WriteLine($"Promedio cura:      {promedioCura:F2} ms");