using UnityEngine;
using System;

public class NPCDestroyHandler : MonoBehaviour
{
    public event Action OnCarDestroyed;

    private void OnDestroy()
    {
        // Llamar al evento al destruir el objeto
        OnCarDestroyed?.Invoke();
    }
}
