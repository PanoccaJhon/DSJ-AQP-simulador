using UnityEngine;
using TMPro; // Para TextMeshPro
using UnityEngine.SceneManagement;

public class GamePlayerController : MonoBehaviour
{
    public int points = 100; // Puntos iniciales

    public int objetivos = 0; // Objetivos alcanzados

    public TextMeshProUGUI pointsText; // Referencia al texto UI

    public TextMeshProUGUI objetivosText; // Referencia al texto UI

    public GameObject gameOverPanel; // Panel de "Juego Terminado"

    public GameObject finJuegoPanel; // Panel de "Juego Terminado"

    private bool isGameOver = false;

    private void Start()
    {
        UpdatePointsText();
        gameOverPanel.SetActive(false); // Ocultar el panel al inicio
        finJuegoPanel.SetActive(false); // Ocultar el panel al inicio
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bordes"))
        {
            ReducePoints(10); // Por ejemplo, restar 10 puntos por colisión
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            ReducePoints(40); // Por ejemplo, restar 40 puntos por colisión 
        }else if (collision.gameObject.CompareTag("Objetivo"))
        {
            
            points += 5; // Por ejemplo, sumar 50 puntos por colisión
            UpdatePointsText();
            addObjetivo();
        }
    }

    void addObjetivo()
    {
        objetivos++;
        UpdateObjetivosText();

        if (objetivos >= 7)
        {
            FinJuego();
        }
    }

    void ReducePoints(int amount)
    {
        points -= amount;
        points = Mathf.Max(points, 0); // Asegura que no sea menor a 0
        UpdatePointsText();

        if (points <= 0)
        {
            EndGame();
        }
    }

    void UpdatePointsText()
    {
        pointsText.text = "" + points;
    }

    void UpdateObjetivosText()
    {
        objetivosText.text = objetivos + "/7";
    }

    void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0; // Pausa el juego
        gameOverPanel.SetActive(true); // Muestra el panel de "Juego Terminado"
    }

    void FinJuego()
    {
        isGameOver = true;
        Time.timeScale = 0; // Pausa el juego
        finJuegoPanel.SetActive(true); // Muestra el panel de "Juego Terminado"
    }

    // Métodos para los botones de la UI
    public void RetryGame()
    {
        Time.timeScale = 1; // Reanuda el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1; // Reanuda el tiempo
        SceneManager.LoadScene(0); // Cambia a la escena del menú
    }
}
