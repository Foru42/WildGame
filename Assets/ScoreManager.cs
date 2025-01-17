using TMPro;  // Aseg�rate de incluir el espacio de nombres de TextMesh Pro
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI marcadorText; // Referencia al componente TextMeshProUGUI
    private int puntuacion = 0;

    void Start()
    {
        ActualizarMarcador(); // Actualizar al principio
    }

    public void AumentarPuntuacion(int puntos)
    {
        puntuacion += puntos;
        ActualizarMarcador();
    }

    // M�todo p�blico para actualizar el marcador
    public void ActualizarMarcador()
    {
        marcadorText.text = "Puntuaci�n: " + puntuacion.ToString();
    }
}
