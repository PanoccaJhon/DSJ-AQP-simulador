using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AutoPrincipal : MonoBehaviour
{
    public float speed = 10f;        // Velocidad del auto
    public float turnSpeed = 50f;    // Velocidad de giro

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento hacia adelante y hacia atrás
        float moveDirection = Input.GetAxis("Vertical") * speed;
        
        // Rotación hacia la izquierda y derecha
        float turnDirection = Input.GetAxis("Horizontal") * turnSpeed;

        // Aplicar movimiento y rotación
        Vector3 move = transform.forward * moveDirection * Time.deltaTime;
        rb.MovePosition(rb.position + move);

        Quaternion turn = Quaternion.Euler(0f, turnDirection * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}
