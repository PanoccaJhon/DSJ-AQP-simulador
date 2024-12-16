using UnityEngine;

public class WayPointsEjercito : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnDrawGizmos() {
        
        foreach (Transform child in transform) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(child.position, 0.3f);
        }

        Gizmos.color = Color.blue;
        for (int i = 0; i < transform.childCount-1; i++) {
            Vector3 currentWayPoint = transform.GetChild(i).position;
            Vector3 previousWayPoint = transform.GetChild(i+1).position;
            Gizmos.DrawLine(previousWayPoint, currentWayPoint);
        }
    }

    public Transform GetNextWayPoint(Transform currentWayPoint) {
        if(currentWayPoint == null) {
            return transform.GetChild(0);
        }

        int currentWayPointIndex = currentWayPoint.GetSiblingIndex();
        if (currentWayPointIndex == transform.childCount - 1) {
            return transform.GetChild(0);
        }
        return transform.GetChild(currentWayPointIndex + 1);
        
    }
}
