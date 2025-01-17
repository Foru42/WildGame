using UnityEngine;

public class JokoaBukatu : MonoBehaviour
{
    public GameObject bolaPrefab; // Prefab de la bola para crear una nueva
    public Transform posicionInicial; // Posición inicial donde aparecerá la nueva bola
    public PlungerAnimazioa plungerScript; // Referencia al script del plunger
    public GameObject muroAdicional; // Referencia al muro adicional

    private GameObject bolaActual; // Referencia a la bola actual

    private void Start()
    {
        // Buscar la bola inicial en la escena
        bolaActual = GameObject.FindGameObjectWithTag("Ball");

        // Asegurarnos de que el muro esté desactivado al inicio
        if (muroAdicional != null)
        {
            muroAdicional.SetActive(false);
        }

        // Actualizar la referencia de la bola en el plunger
        if (plungerScript != null && bolaActual != null)
        {
            plungerScript.bola = bolaActual.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si la bola colisiona con este collider
        if (other.CompareTag("Ball"))
        {
            // Eliminar la bola actual
            if (bolaActual != null)
            {
                Destroy(bolaActual);
            }

            // Crear una nueva bola en la posición inicial
            bolaActual = Instantiate(bolaPrefab, posicionInicial.position, Quaternion.identity);

            // Actualizar la referencia de la bola en el plunger
            if (plungerScript != null && bolaActual != null)
            {
                plungerScript.bola = bolaActual.GetComponent<Rigidbody>();
            }

            // Desactivar el muro adicional
            if (muroAdicional != null)
            {
                muroAdicional.SetActive(false);
            }

            // Reactivar el plunger
            if (plungerScript != null)
            {
                plungerScript.enabled = true;
            }
        }
    }
}
