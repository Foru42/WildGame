using UnityEngine;
using System.Collections;

public class PlungerEzfuntziona : MonoBehaviour
{
    public PlungerAnimazioa plungerScript; // Referencia al script del plunger
    public Rigidbody bola; // Referencia al Rigidbody de la bola
    public float fuerzaMinimaDisparo = 100f; // Fuerza m�nima para que el disparo sea considerado como efectivo

    private bool bolaEnPosicion = false; // Para saber si la bola est� en la posici�n correcta para disparar

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


            bolaEnPosicion = true; // La bola ha entrado en la zona de disparo
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si la bola sale del detector
        if (other.CompareTag("Ball"))
        {
            // Comprobar si la bola no ha sido disparada con suficiente fuerza
            if (bola.linearVelocity.magnitude < fuerzaMinimaDisparo)
            {
                // Si no se dispar� con suficiente fuerza, habilitar de nuevo el plunger
                if (plungerScript != null)
                {
                    plungerScript.enabled = true;
                }
            }

            bolaEnPosicion = false; // La bola ha salido de la zona
        }
    }

}
