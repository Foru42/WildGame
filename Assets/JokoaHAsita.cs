using UnityEngine;

public class JokoaHAsita : MonoBehaviour
{

    public PlungerAnimazioa plungerScript; // Referencia al script del plunger
    public GameObject muroAdicional; // El muro que aparecerá después de que la bola salga

    private void Start()
    {
        // Asegurarnos de que el muro adicional esté desactivado al inicio
        if (muroAdicional != null)
        {
            muroAdicional.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la bola colisiona con el detector
        if (other.CompareTag("Ball"))
        {
            // Desactivar el plunger para que no se pueda usar el espacio
            if (plungerScript != null)
            {
                plungerScript.enabled = false;
            }

            // Activar el muro adicional
            
                StartCoroutine(ActivarMuroConRetardo(0.5f));
               
            
        }
    }
    private System.Collections.IEnumerator ActivarMuroConRetardo(float segundos)
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(segundos);

        // Activar el muro adicional
        if (muroAdicional != null)
        {
            muroAdicional.SetActive(true);
        }
    }
}
