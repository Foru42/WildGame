using UnityEngine;
using UnityEngine.UI; // Importante para usar el Text de UI

public class ScoreManager : MonoBehaviour
{
    public int puntuacion = 0;  // Variable para llevar el conteo de la puntuación
    public Text marcadorText;   // Referencia al texto donde se muestra la puntuación

    private void Start()
    {
        // Si el marcadorText no está asignado, buscar el objeto de texto en el Canvas
        if (marcadorText == null)
        {
            marcadorText = FindFirstObjectByType<Text>(); // Buscar el Text en la escena
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
        // Actualizar el texto con la nueva puntuación
        marcadorText.text = "Puntuazioa: " + puntuacion.ToString();
    }
    public int GetPuntuacion()
    {
        return puntuacion;
    }
}
