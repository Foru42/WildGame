using UnityEngine;

public class PlungeAnimazioa : StateMachineBehaviour
{
    public Animator animator; // Referencia al Animator

    void Update()
    {
        // Detectar si el espacio est� presionado
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isCompressing", true); // Activar animaci�n de compresi�n
        }
        else
        {
            animator.SetBool("isCompressing", false); // Volver a la animaci�n relajada
        }
    }
}
