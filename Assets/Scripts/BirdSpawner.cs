using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab; // Prefab del ave
    public int numberOfBirds = 20; // Número de aves a generar
    public Vector3 spawnArea = new Vector3(10, 10, 10); // Tamaño del área de generación

    void Start()
    {
        SpawnBirds();
    }

    void SpawnBirds()
    {
        for (int i = 0; i < numberOfBirds; i++)
        {
            // Generar posición aleatoria dentro del área
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Crear la instancia del prefab del ave
            GameObject bird = Instantiate(birdPrefab, randomPosition, Quaternion.identity);

            // Inicializar el ave con los límites del área de generación
            BirdMovement birdMovement = bird.GetComponent<BirdMovement>();
            if (birdMovement != null)
            {
                birdMovement.Initialize(transform.position, spawnArea);
            }
            else
            {
                Debug.LogError("El prefab de ave no tiene el componente BirdMovement.");
            }
        }
    }

    // Visualizar el área de generación en el Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}
