using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPuntuazioa : MonoBehaviour
{
    public TextMeshProUGUI puntuacionText;

    private void Start()
    {
        if (puntuacionText != null)
        {
            puntuacionText.text = "" + PuntuakGorde.ObtenerTotalPuntos();
        }
        else
        {
            Debug.LogError("No se ha asignado el Text en el inspector.");
        }
    }
}
