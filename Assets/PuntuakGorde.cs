using UnityEngine;

public class PuntuakGorde : MonoBehaviour
{
    // Puntos del primer nivel
    public static int puntosNivel1 = 0;

    // Puntos del segundo nivel
    public static int puntosNivel2 = 0;

    // M�todo para obtener el total de puntos acumulados
    public static int ObtenerTotalPuntos()
    {
        return puntosNivel1 + puntosNivel2;
    }
}
