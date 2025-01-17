using UnityEngine;
using UnityEngine.SceneManagement;

public class BumperRebotea : MonoBehaviour
{
    public float fuerzaRebote = 1f; // Fuerza del rebote exagerado
    private ScoreManager scoreManager; // Referencia al ScoreManager

    private void Start()
    {
        // Buscar el ScoreManager en el escenario
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la bola colisiona con el bumper
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Aplicar un rebote exagerado
            Rigidbody bolaRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (bolaRigidbody != null)
            {
                // Aplicar una fuerza de rebote exagerada
                bolaRigidbody.AddForce(collision.contacts[0].normal * fuerzaRebote, ForceMode.Impulse);
            }

            // Incrementar la puntuación
            if (scoreManager != null)
            {
                scoreManager.AumentarPuntuacion(1); // Aumenta 1 punto por colisión
            }
        }
    }
}
