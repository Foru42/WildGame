using UnityEngine;

public class PlungeAnimazioa : StateMachineBehaviour
{
    public Animator animator; // Referencia al Animator

    void Update()
    {
        // Detectar si el espacio está presionado
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isCompressing", true); // Activar animación de compresión
        }
        else
        {
            animator.SetBool("isCompressing", false); // Volver a la animación relajada
        }
    }
}
