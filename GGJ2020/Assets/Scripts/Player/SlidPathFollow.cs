using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WayPointState {WAIT, PASSTHROUGH };

[System.Serializable]
public class WayPoints
{

    public Transform wayPoint;
    public WayPointState state;

}
public class SlidPathFollow : MonoBehaviour
{
    //List of waypoints to pass through. Also has the state of the waypoint to know if we should wait for the player.
    public WayPoints[] wayPoints;
    private int actualWayPoint = 0;

    public float speed = 6f;
    public float damperRadius = 0.33f;
    private bool isMoving = false;

    private Vector3 targetWaypointVectorPosition;

    private TrailRenderer tail;
    public float shortTail = 0.5f;
    public float longTail = 5f;

    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = wayPoints[actualWayPoint].wayPoint.position;
        targetWaypointVectorPosition = transform.position;

        tail = GetComponentInChildren<TrailRenderer>(); ;
        if (tail == null)
        {
            Debug.LogError("No trail renderer found");
        }
        tail.time = shortTail;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            //reduce the time of the trailrenderer
            tail.time = shortTail;
            //We are not moving, no need to do any checking. Just wait for the player.
            return;
        }
        else
        {
            tail.time = longTail;
        }


        //Have we arrived at a waiting waypoint ?
        if ((wayPoints[actualWayPoint].wayPoint.position - gameObject.transform.position).magnitude < damperRadius)
        {
            //Debug.Log("arrived at waypoint");
            if (wayPoints[actualWayPoint].state == WayPointState.WAIT)
            {
                //We are waiting fot the player to catch up
                //just wait and be special !!!
                isMoving = false;
                //Set to be actualy centered on the waypoint
                gameObject.transform.position = wayPoints[actualWayPoint].wayPoint.position;
                targetWaypointVectorPosition = transform.position;
                return;
            }
            else if (wayPoints[actualWayPoint].state == WayPointState.PASSTHROUGH)
            {
                // We have reached a passthrough, move on
                SetNextWaypoint();
            }
            else
            {
                Debug.LogError("somthing went wrong");
            }
        }

        //move to next waypoint.
        transform.position = Vector3.MoveTowards(transform.position, targetWaypointVectorPosition, speed * Time.deltaTime);
        //TODO: Might have to take care of speed. maybe in the set next waypoint. We might get a speed that varies too much depending on the distance between the waypoints.



    }

    void SetNextWaypoint()
    {
        actualWayPoint += 1;
        if (actualWayPoint >= wayPoints.Length)
        {
            //end of line, destroy
            Destroy(gameObject);
            return;
        }
        targetWaypointVectorPosition = wayPoints[actualWayPoint].wayPoint.position;
        isMoving = true;
    }

    void OnTriggerEnter(Collider col)
    {
        //if the player hits the sphere and we are waitin, go to next waypoint.
        if (col.tag == "Player" && !isMoving)
        {
            SetNextWaypoint();
        }
    }

    //gismis for ease of use
    void OnDrawGizmosSelected()
    {
        if (wayPoints.Length > 1)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < wayPoints.Length - 1; i++)
            {
                Gizmos.DrawLine(wayPoints[i].wayPoint.position, wayPoints[i + 1].wayPoint.position);
                Gizmos.DrawSphere(wayPoints[i].wayPoint.position, 1);
            }
            Gizmos.DrawSphere(wayPoints[wayPoints.Length - 1].wayPoint.position, 1);

        }
    }
}
