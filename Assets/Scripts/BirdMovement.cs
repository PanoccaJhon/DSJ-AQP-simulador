using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de las aves
    private Vector3 direction; // Dirección actual del movimiento
    private Vector3 spawnCenter; // Centro del área
    private Vector3 spawnBounds; // Límites del área

    // Inicializar el ave con los límites del área
    public void Initialize(Vector3 center, Vector3 bounds)
    {
        spawnCenter = center;
        spawnBounds = bounds;
        direction = Random.insideUnitSphere.normalized; // Dirección inicial aleatoria
    }

    void Update()
    {
        // Mover el ave en la dirección actual
        transform.position += direction * speed * Time.deltaTime;

        // Verificar si el ave está fuera de los límites y rebotar
        Vector3 offset = transform.position - spawnCenter;

        if (Mathf.Abs(offset.x) > spawnBounds.x / 2)
            direction.x = -direction.x;
        if (Mathf.Abs(offset.y) > spawnBounds.y / 2)
            direction.y = -direction.y;
        if (Mathf.Abs(offset.z) > spawnBounds.z / 2)
            direction.z = -direction.z;

        // Ajustar la rotación hacia la dirección del movimiento
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
