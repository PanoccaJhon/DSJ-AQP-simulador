using UnityEngine;
using System;

public class DestroyedCarNotifier : MonoBehaviour
{
    public event Action OnCarDestroyed;

    private void OnDestroy()
    {
        OnCarDestroyed?.Invoke();
    }
}
