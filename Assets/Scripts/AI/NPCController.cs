using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private WayPointsEjercito waypoints;
    [SerializeField] private float speed = 10f; // Velocidad máxima
    [SerializeField] private float turnSpeed = 0.5f; // Sensibilidad al girar
    [SerializeField] private float brakingDistance = 5f; // Distancia a la que empieza a frenar
    [SerializeField] private float distanceThreshold = 0.5f; // Distancia para cambiar al siguiente waypoint

    private Transform currentWaypoint;
    private NPCDriveController carController; // Referencia al controlador del auto

    private void Start()
    {
        // Obtener la referencia al controlador del auto
        carController = GetComponent<NPCDriveController>();

        // Configurar el primer waypoint
        currentWaypoint = waypoints.GetNextWayPoint(null);
        transform.position = currentWaypoint.position;

        // Configurar el siguiente waypoint como objetivo
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
    }

    private void Update()
    {
        // Movimiento hacia el siguiente waypoint
        FollowWaypoints();
    }

    private void FollowWaypoints()
    {
        // Calcular dirección hacia el waypoint actual
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;

        // Girar el vehículo hacia el waypoint
        float targetAngle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
        float horizontalInput = Mathf.Clamp(targetAngle / 90f, -1f, 1f); // Normalizar ángulo a un rango de -1 a 1

        // Calcular distancia al waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, currentWaypoint.position);

        // Determinar si frenar y ajustar la velocidad
        bool isBraking = distanceToWaypoint <= brakingDistance;
        
        // Dejar de acelerar si la distancia es menor a la de frenado
        float verticalInput = isBraking ? 0f : 1f;
        
        
        // Enviar inputs al controlador del auto
        carController.SetInputs(horizontalInput, verticalInput, isBraking);

        // Avanzar al siguiente waypoint si estamos cerca
        if (distanceToWaypoint < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        }
    }
}
