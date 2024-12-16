using UnityEngine;

public class Way : MonoBehaviour
{
    public Transform[] waypoints; // Arreglo de puntos de ruta
    public float speed = 5f; // Velocidad del objeto
    private int currentWaypointIndex = 0; // Índice del waypoint actual

    void Update()
    {
        // Si no hay waypoints, no hacer nada
        if (waypoints.Length == 0)
            return;

        // Mover el objeto hacia el waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Verificar si el objeto está cerca del waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Avanzar al siguiente waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Volver al inicio (recorrido cíclico)
            }
        }
    }
}
