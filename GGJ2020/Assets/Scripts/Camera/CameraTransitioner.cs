using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitioner : MonoBehaviour
{
    public Transform startViewPoint;

    public Transform target;
    public Transform[] viewPoints;
    public float transitionSpeed = 3.0f;
    private void Start()
    {
        transform.position = startViewPoint.position;
    }

    void Update()
    {
        Vector3 targetPosition = GetClosestWaypoint().position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);
    }

    private Transform GetClosestWaypoint()
    {
        int closestWaypointIndex = 0;
        float lowestDistance = float.MaxValue;

        for (int i = 0; i < viewPoints.Length; i++)
        {
            float distance = Vector3.Distance(target.position, viewPoints[i].position);

            if (distance < lowestDistance)
            {
                lowestDistance = distance;
                closestWaypointIndex = i;
            }
        }

        return viewPoints[closestWaypointIndex];
    }
}
