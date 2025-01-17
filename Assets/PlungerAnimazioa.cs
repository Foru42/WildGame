using UnityEngine;

public class PlungerAnimazioa : MonoBehaviour
{
    private Animator animator; // Referencia al Animator
    public Rigidbody bola; // Referencia al Rigidbody de la bola
    public float fuerzaBase = 500f; // Fuerza mínima de disparo
    public float fuerzaMaxima = 1500f; // Fuerza máxima de disparo
    public float tiempoMaximoCarga = 2f; // Tiempo necesario para alcanzar la fuerza máxima

    private bool isCompressing = false; // Para saber si el plunger está comprimido
    private float tiempoCargando = 0f; // Tiempo que se ha mantenido presionado el espacio

    void Start()
    {
        // Obtener el componente Animator en el mismo GameObject
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator no encontrado en el GameObject.");
        }
    }

    void Update()
    {
        // Detectar si el espacio está presionado
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isCompressing", true);
            isCompressing = true; // Marcar como comprimido
            tiempoCargando += Time.deltaTime; // Incrementar el tiempo de carga
        }
        else if (isCompressing) // Detectar cuando se suelta el espacio
        {
            animator.SetBool("isCompressing", false);
            isCompressing = false; // Restablecer estado
            DispararBola(); // Disparar la bola
            tiempoCargando = 0f; // Restablecer el tiempo de carga
        }
    }

    void DispararBola()
    {
        // Calcular la fuerza en función del tiempo cargado
        float fuerzaDisparo = Mathf.Lerp(fuerzaBase, fuerzaMaxima, Mathf.Clamp01(tiempoCargando / tiempoMaximoCarga));

        // Aplicar la fuerza en la dirección del plunger
        Vector3 direccionDisparo = transform.forward;
        bola.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.Impulse);

        // Limitar la velocidad máxima de la bola
        float velocidadMaxima = 1f; // Ajusta según lo necesario
        if (bola.linearVelocity.magnitude > velocidadMaxima)
        {
            bola.linearVelocity = bola.linearVelocity.normalized * velocidadMaxima;
        }
    }
}
