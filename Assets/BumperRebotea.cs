using UnityEngine;

public class BumperRebotea : MonoBehaviour
{
    public float fuerzaRebote = 5f; // Fuerza del rebote moderada
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
            // Aplicar un rebote moderado
            Rigidbody bolaRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (bolaRigidbody != null)
            {
                // Determinar la dirección del rebote
                Vector3 direccionRebote = collision.contacts[0].normal.normalized;

                // Aplicar una fuerza moderada sin depender de la velocidad de entrada
                bolaRigidbody.AddForce(direccionRebote * fuerzaRebote, ForceMode.Impulse);
            }

            // Incrementar la puntuación
            if (scoreManager != null)
            {
                scoreManager.AumentarPuntuacion(2); // Aumenta 1 punto por colisión
            }
        }
    }
}
