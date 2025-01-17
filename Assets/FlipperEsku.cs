using UnityEngine;

public class FlipperEsku : MonoBehaviour
{
    public KeyCode teclaAccion = KeyCode.RightArrow; // Tecla para activar el flipper
    public float fuerzaMotor = 1000f; // Fuerza del motor
    public float velocidadMotor = 100f; // Velocidad de rotación del motor
    public bool invertirMovimiento = false; // Invertir la dirección del flipper si es necesario

    private HingeJoint bisagra;
    private JointMotor motor;

    void Start()
    {
        // Obtener el componente Hinge Joint
        bisagra = GetComponent<HingeJoint>();

        // Configurar el motor
        motor = bisagra.motor;
        motor.targetVelocity = 0f;
        motor.force = fuerzaMotor;
        bisagra.motor = motor;
        bisagra.useMotor = true; // Activar el uso del motor
    }

    void Update()
    {
        // Detectar la tecla para activar el flipper
        if (Input.GetKey(teclaAccion))
        {
            // Activar el motor para mover el flipper
            motor.targetVelocity = invertirMovimiento ? -velocidadMotor : velocidadMotor;
        }
        else
        {
            // Detener el motor para devolver el flipper
            motor.targetVelocity = invertirMovimiento ? velocidadMotor : -velocidadMotor;
        }

        // Actualizar el motor en el Hinge Joint
        bisagra.motor = motor;
    }
}
