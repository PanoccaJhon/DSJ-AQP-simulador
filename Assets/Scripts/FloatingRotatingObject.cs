using UnityEngine;

public class FloatingRotatingObject : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidad de rotación (grados por segundo)
    public float floatAmplitude = 0.5f; // Amplitud del movimiento vertical
    public float floatFrequency = 1f; // Frecuencia del movimiento vertical

    private Vector3 startPosition;

    private void Start()
    {
        // Guardar la posición inicial del objeto
        startPosition = transform.position;
    }

    private void Update()
    {
        // Rotar el objeto constantemente alrededor del eje Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Crear el movimiento de flotación (senoidal)
        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica si el objeto colisionante tiene la etiqueta "Player"
        {
            Debug.Log("Jugador alcanzó el objetivo.");
            
            // Aquí puedes manejar la lógica adicional si es necesario
            Destroy(gameObject); // Destruye el objeto actual (este objetivo)
        }
    }
}
