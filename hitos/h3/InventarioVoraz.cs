namespace H3;

public static class InventarioVoraz
{
    public static int BuscarDisponible(bool[] inventario)
    {
        for (int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i])
                return i;
        }

        return -1;
    }
}