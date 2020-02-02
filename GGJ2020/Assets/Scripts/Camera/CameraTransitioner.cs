using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitioner : MonoBehaviour
{
    public Transform startViewPoint;

    public Transform target;
    private Transform[] viewPoints = null;
    public Transform[] viewPointsLevel1;
    public Transform[] viewPointsLevel2;
    public Transform[] viewPointsLevel3;
    public float transitionSpeed = 3.0f;
    public LevelManager levelManager;

    private void Start()
    {
        transform.position = startViewPoint.position;
    }

    void Update()
    {
        if (levelManager.loadedLevel > 0)
        {
            UpdateViewPoints();
        }
        Vector3 targetPosition = GetClosestWaypoint().position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);
    }

    private void UpdateViewPoints()
    {
        switch (levelManager.loadedLevel)
        {
            case 1:
                viewPoints = viewPointsLevel1;
                break;
            case 2:
                viewPoints = viewPointsLevel2;
                break;
            case 3:
                viewPoints = viewPointsLevel3;
                break;
            default:
                viewPoints = viewPointsLevel1;
                break;
        }
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
