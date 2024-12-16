using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; // Asigna el panel desde el Inspector

    private void Start()
    {
        // Asegúrate de que el panel esté oculto al inicio
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    private void Update()
    {
        // Detectar si la tecla M ha sido presionada
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Alternar la visibilidad del panel
            if (panel != null)
            {
                bool isActive = panel.activeSelf;
                panel.SetActive(!isActive);
            }
        }
    }
}
