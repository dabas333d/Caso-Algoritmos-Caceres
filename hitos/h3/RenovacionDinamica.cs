namespace H3;

public static class RenovacionDinamica
{
    public static int Resolver(
        Computadora[] equipos,
        int presupuesto)
    {
        int n = equipos.Length;

        int[,] dp =
            new int[n + 1, presupuesto + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int p = 0; p <= presupuesto; p++)
            {
                dp[i, p] = dp[i - 1, p];

                if (equipos[i - 1].Costo <= p)
                {
                    dp[i, p] =
                        Math.Max(
                            dp[i, p],
                            dp[i - 1,
                               p - equipos[i - 1].Costo]
                            + equipos[i - 1].Beneficio);
                }
            }
        }

        return dp[n, presupuesto];
    }
}