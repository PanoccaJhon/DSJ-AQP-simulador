using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public Transform objective; // Referencia al objetivo
    public TextMeshProUGUI distanceText; // Texto para mostrar la distancia
    public RectTransform directionIndicator; // Indicador direccional (puede ser un sprite o UI Element)

    private void Update()
    {
        UpdateDistance();
        UpdateDirection();
    }

    void UpdateDistance()
    {
        float distance = Vector3.Distance(player.position, objective.position);
        distanceText.text = "Distancia: " + distance.ToString("F1") + " m"; // Muestra la distancia con 1 decimal
    }

    void UpdateDirection()
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direction = objective.position - player.position;
        Vector3 flatDirection = new Vector3(direction.x, 0, direction.z).normalized; // Ignora la altura (eje Y)

        // Proyecta la dirección en la pantalla
        float angle = Vector3.SignedAngle(player.forward, flatDirection, Vector3.up);

        // Rota el indicador direccional
        directionIndicator.localRotation = Quaternion.Euler(0, 0, -angle); // Apunta hacia el objetivo
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MissionComplete();
        }
    }

    void MissionComplete()
    {
        Debug.Log("¡Misión completada!");
        // Aquí puedes mostrar un mensaje o ejecutar lógica adicional
    }
}
