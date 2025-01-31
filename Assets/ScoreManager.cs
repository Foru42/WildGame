using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public int puntuacion = 0; // Variable para llevar el conteo de la puntuación
    public TextMeshPro marcadorText;

    private void Start()
    {
        // Si marcadorText no está asignado, buscar un TextMesh en la escena
        if (marcadorText == null)
        {
            marcadorText = FindFirstObjectByType<TextMeshPro>();  // Busca el primer TextMesh en la escena
        }

        // Actualizar el marcador al inicio
        ActualizarMarcador();
    }

    public void AumentarPuntuacion(int cantidad)
    {
        // Incrementar la puntuación
        puntuacion += cantidad;
        // Actualizar el marcador en pantalla
        ActualizarMarcador();
    }

    private void ActualizarMarcador()
    {
        // Actualizar el texto del TextMesh con la nueva puntuación
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
