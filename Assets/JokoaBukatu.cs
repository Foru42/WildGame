using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JokoaBukatu : MonoBehaviour
{
    public GameObject bolaPrefab;
    public Transform posicionInicial;
    public PlungerAnimazioa plungerScript;
    public GameObject muroAdicional;
    public ScoreManager scoreManager;
    public Text gameOverText;

    private GameObject bolaActual;

    private void Start()
    {
        bolaActual = GameObject.FindGameObjectWithTag("Ball");

        if (muroAdicional != null)
        {
            muroAdicional.SetActive(false);
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (plungerScript != null && bolaActual != null)
        {
            plungerScript.bola = bolaActual.GetComponent<Rigidbody>();
        }

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager no asignado a JokoaBukatu.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (scoreManager != null)
            {
                if (SceneManager.GetActiveScene().buildIndex == 3) // Nivel 2
                {
                    if (scoreManager.GetPuntuacion() >= 30)
                    {
                        PuntuakGorde.puntosNivel2 = scoreManager.GetPuntuacion();
                        MostrarMensajeFinal("COMPLETED");
                        return;
                    }
                }
                else // Nivel 1
                {
                    if (scoreManager.GetPuntuacion() >= 30)
                    {
                        PuntuakGorde.puntosNivel1 = scoreManager.GetPuntuacion();
                        SceneManager.LoadScene(3); // Cargar Nivel 2
                        return;
                    }
                }

                scoreManager.AumentarPuntuacion(-5);

                if (scoreManager.GetPuntuacion() <= 0)
                {
                    scoreManager.AumentarPuntuacion(5);
                    GameOver();
                    return;
                }
            }

            if (bolaActual != null)
            {
                Destroy(bolaActual);
            }

            bolaActual = Instantiate(bolaPrefab, posicionInicial.position, Quaternion.identity);

            if (plungerScript != null && bolaActual != null)
            {
                plungerScript.bola = bolaActual.GetComponent<Rigidbody>();
            }

            if (muroAdicional != null)
            {
                muroAdicional.SetActive(false);
            }

            if (plungerScript != null)
            {
                plungerScript.enabled = true;
            }
        }
    }

    private void MostrarMensajeFinal(string mensaje)
    {
        if (gameOverText != null)
        {
            gameOverText.text = mensaje;
            gameOverText.gameObject.SetActive(true);
        }
        PuntuakGorde.puntosNivel2 = scoreManager.GetPuntuacion();
        Invoke(nameof(CargarMenuFinal), 3f);
    }

    private void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER";
            gameOverText.gameObject.SetActive(true);
        }

        Invoke(nameof(CargarMenuPrincipal), 3f);
    }

    private void CargarMenuFinal()
    {
        SceneManager.LoadScene(4); // Menú principal
    }

    private void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }


}
