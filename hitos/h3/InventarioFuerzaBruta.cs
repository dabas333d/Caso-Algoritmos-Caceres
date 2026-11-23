namespace H3;

public static class InventarioFuerzaBruta
{
    public static int BuscarDisponible(bool[] inventario)
    {
        int encontrado = -1;

        for (int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i])
            {
                encontrado = i;
            }
        }

        return encontrado;
    }
}