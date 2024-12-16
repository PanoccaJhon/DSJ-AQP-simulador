using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject[] carPrefabs; // Lista de prefabs de autos
    public Transform waypointsParent; // Objeto padre de los waypoints

    [Header("Spawn Settings")]
    public float spawnInterval = 5f; // Tiempo entre spawns
    public int maxCars = 10; // Número máximo de autos activos

    private int currentCarCount = 0; // Conteo actual de autos activos

    void Start()
    {
        // Inicia el ciclo de generación de autos
        InvokeRepeating(nameof(SpawnCar), 0f, spawnInterval);
    }

    void SpawnCar()
    {
        // Verifica si el número de autos activos ha alcanzado el límite
        if (currentCarCount >= maxCars)
            return;

        // Selecciona aleatoriamente un prefab de auto
        GameObject randomCarPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];

        // Selecciona aleatoriamente una ruta de waypoints
        Transform randomRoute = waypointsParent.GetChild(Random.Range(0, waypointsParent.childCount));
        
        // Verifica que la ruta tenga waypoints
        if (randomRoute.childCount == 0)
        {
            Debug.LogWarning("La ruta seleccionada no tiene waypoints.");
            return;
        }

        // Obtén el primer waypoint de la ruta
        Transform firstWaypoint = randomRoute.GetChild(0);

        // Genera el auto en la posición del primer waypoint
        GameObject spawnedCar = Instantiate(randomCarPrefab, firstWaypoint.position, Quaternion.identity);
        
        // Agrega el componente CarAIController si no existe
        RCC_AICarController aiController = spawnedCar.GetComponent<RCC_AICarController>();
        if (aiController == null)
            aiController = spawnedCar.AddComponent<RCC_AICarController>();

        // Asigna la ruta al CarAIController
        aiController.waypointsContainer = randomRoute.GetComponent<RCC_AIWaypointsContainer>();

        // Incrementa el conteo de autos activos
        currentCarCount++;

        // Escucha el evento de destrucción del auto para decrementar el conteo
        DestroyedCarNotifier carNotifier = spawnedCar.AddComponent<DestroyedCarNotifier>();
        carNotifier.OnCarDestroyed += () => currentCarCount--;
    }
}
