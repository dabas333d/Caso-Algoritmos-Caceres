namespace H3;

public static class RenovacionFuerzaBruta
{
    public static int Resolver(
        Computadora[] equipos,
        int presupuesto)
    {
        return ResolverRec(
            equipos,
            presupuesto,
            0);
    }

    private static int ResolverRec(
        Computadora[] equipos,
        int presupuesto,
        int indice)
    {
        if (indice >= equipos.Length)
            return 0;

        int sinTomar =
            ResolverRec(
                equipos,
                presupuesto,
                indice + 1);

        if (equipos[indice].Costo > presupuesto)
            return sinTomar;

        int tomando =
            equipos[indice].Beneficio +
            ResolverRec(
                equipos,
                presupuesto - equipos[indice].Costo,
                indice + 1);

        return Math.Max(sinTomar, tomando);
    }
}