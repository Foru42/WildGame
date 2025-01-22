using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para manejar UI

public class JokoaBukatu : MonoBehaviour
{
    public GameObject bolaPrefab; // Prefab de la bola para crear una nueva
    public Transform posicionInicial; // Posición inicial donde aparecerá la nueva bola
    public PlungerAnimazioa plungerScript; // Referencia al script del plunger
    public GameObject muroAdicional; // Referencia al muro adicional
    public ScoreManager scoreManager; // Referencia al ScoreManager
    public Text gameOverText; // Referencia al Text en la UI

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

        // Asegurarnos de que el Text esté desactivado al inicio
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        // Actualizar la referencia de la bola en el plunger
        if (plungerScript != null && bolaActual != null)
        {
            plungerScript.bola = bolaActual.GetComponent<Rigidbody>();
        }

        // Verificar si el ScoreManager está asignado
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager no asignado a JokoaBukatu.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si la bola colisiona con este collider
        if (other.CompareTag("Ball"))
        {
            // Restar puntos en el marcador si el ScoreManager está asignado
            if (scoreManager != null)
            {
                scoreManager.AumentarPuntuacion(-5);

                // Comprobar si la puntuación es menor que 0
                if (scoreManager.GetPuntuacion() < 0)
                {
                    GameOver();
                    return; // Detener la ejecución para evitar crear una nueva bola
                }
            }

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

    private void GameOver()
    {
        // Mostrar el mensaje de "Game Over" en el Text
        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER";
            gameOverText.gameObject.SetActive(true);
        }

        // Esperar 3-4 segundos y luego cargar el menú principal
        Invoke(nameof(CargarMenuPrincipal), 3f); // Llama a la función después de 3 segundos
    }

    private void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0); // Cargar el menú principal (Scene 0)
    }
}
