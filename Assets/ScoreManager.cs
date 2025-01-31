using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public int puntuacion = 0; // Variable para llevar el conteo de la puntuaci�n
    public TextMeshPro marcadorText;

    private void Start()
    {
        // Si marcadorText no est� asignado, buscar un TextMesh en la escena
        if (marcadorText == null)
        {
            marcadorText = FindFirstObjectByType<TextMeshPro>();  // Busca el primer TextMesh en la escena
        }

        // Actualizar el marcador al inicio
        ActualizarMarcador();
    }

    public void AumentarPuntuacion(int cantidad)
    {
        // Incrementar la puntuaci�n
        puntuacion += cantidad;
        // Actualizar el marcador en pantalla
        ActualizarMarcador();
    }

    private void ActualizarMarcador()
    {
        // Actualizar el texto del TextMesh con la nueva puntuaci�n
        if (marcadorText != null)
        {
            marcadorText.text = "Points: " + puntuacion.ToString();
        }
        else
        {
            Debug.LogWarning("TextMesh no asignado. No se puede actualizar el marcador.");
        }
    }

    public int GetPuntuacion()
    {
        return puntuacion;
    }
}
