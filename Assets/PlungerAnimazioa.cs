using UnityEngine;

public class PlungerAnimazioa : MonoBehaviour
{
    private Animator animator; // Referencia al Animator
    public Rigidbody bola; // Referencia al Rigidbody de la bola
    public float fuerzaBase = 500f; // Fuerza mínima de disparo
    public float fuerzaMaxima = 1500f; // Fuerza máxima de disparo
    public float tiempoMaximoCarga = 2f; // Tiempo necesario para alcanzar la fuerza máxima

    private bool isTouchActive = false; // Variable para controles táctiles
    private float tiempoCargando = 0f; // Tiempo que se ha mantenido presionado

    private bool isCompressing = false; // Para saber si el plunger está comprimido

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
        if (Input.GetKey(KeyCode.Space) || isTouchActive)
        {
            // Comprimir el plunger mientras se mantenga el toque
            animator.SetBool("isCompressing", true);
            isCompressing = true;
            tiempoCargando += Time.deltaTime;
        }
        else if (tiempoCargando > 0f)
        {
            // Liberar el plunger cuando se suelte el toque
            animator.SetBool("isCompressing", false);
            DispararBola();
            isCompressing = false;
            tiempoCargando = 0f; // Restablecer el tiempo de carga
        }
    }



    public void ActivatePlunger()
    {
        // Activar el estado táctil
        isTouchActive = true;
    }

    public void DeactivatePlunger()
    {
        // Desactivar el estado táctil
        isTouchActive = false;
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
