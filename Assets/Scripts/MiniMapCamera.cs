using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    void LateUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
