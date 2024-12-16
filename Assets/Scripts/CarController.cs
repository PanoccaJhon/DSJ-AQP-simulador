using UnityEngine;

public class CarController : MonoBehaviour
{
    //  // Variables públicas para ajustes
    // public float speed = 10f;          // Velocidad de movimiento
    // public float turnSpeed = 50f;     // Velocidad de giro
    // public float brakeForce = 20f;    // Fuerza de frenado

    // // Variables privadas
    // private float moveInput;          // Entrada de movimiento (adelante/atrás)
    // private float turnInput;          // Entrada de giro (izquierda/derecha)

    // void Update()
    // {
    //     // Obtener entradas del jugador
    //     moveInput = Input.GetAxis("Vertical"); // W/S o flechas arriba/abajo
    //     turnInput = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha

    //     // Mover el auto hacia adelante/atrás
    //     transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);

    //     // Girar el auto
    //     if (moveInput != 0) // Solo permite girar cuando el auto se mueve
    //     {
    //         transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
    //     }
    // }

    // void FixedUpdate()
    // {
    //     // Frenado (opcional)
    //     if (Input.GetKey(KeyCode.Space)) // Usa la barra espaciadora como freno
    //     {
    //         Rigidbody rb = GetComponent<Rigidbody>();
    //         if (rb != null)
    //         {
    //             rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, brakeForce * Time.fixedDeltaTime);
    //         }
    //     }
    // }
}
