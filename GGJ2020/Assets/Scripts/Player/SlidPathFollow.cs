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
public class WayPoint
{

    public Transform wayPoint;

}
public class WaipointAndIndex
{
    public Vector3 theWaypoint;
    public int index;
}
public class SlidPathFollow : MonoBehaviour
{
    //List of waypoints to pass through. Also has the state of the waypoint to know if we should wait for the player.
    public WayPoints[] wayPoints;
  

    public float speed = 6f;
    public float damperRadius = 0.33f;
    private bool isMoving = true;
    public BoolValue isBoosting;
    private int actualWayPoint;

    private Vector3 targetWaypointVectorPosition;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<SurfControl>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = findClosestWayPoints(wayPoints).theWaypoint;
        actualWayPoint = findClosestWayPoints(wayPoints).index;
        targetWaypointVectorPosition = transform.position;

        Debug.Log("start of slide");
        Debug.Log("isMoving on start" + isMoving);
        //tail = GetComponentInChildren<TrailRenderer>();
        //if (tail == null)
        //{
        //    Debug.LogError("No trail renderer found");
        //}
        //tail.time = shortTail;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMoving == false)
        //{
        //    //reduce the time of the trailrenderer
        //    tail.time = shortTail;
        //    //We are not moving, no need to do any checking. Just wait for the player.
        //    return;
        //}
        //else
        //{
        //    tail.time = longTail;
        //}


        //Have we arrived at a waiting waypoint ?
 
            ////Debug.Log("arrived at waypoint");
            //if (wayPoints[actualWayPoint].state == WayPointState.WAIT)
            //{
            //    //We are waiting fot the player to catch up
            //    //just wait and be special !!!
            //    isMoving = false;
            //    //Set to be actualy centered on the waypoint
            //    gameObject.transform.position = wayPoints[actualWayPoint].wayPoint.position;
            //    targetWaypointVectorPosition = transform.position;
            //    return;
            //}
            //else if (wayPoints[actualWayPoint].state == WayPointState.PASSTHROUGH)
            //{
                // We have reached a passthrough, move on
                SetNextWaypoint();
            //}
            //else
            //{
            //    Debug.LogError("somthing went wrong");
            //}
            Debug.Log("isMoving" + isMoving);

        //move to next waypoint.
        Vector3 direction = Vector3.MoveTowards(transform.position, targetWaypointVectorPosition, speed * Time.deltaTime);
        transform.position = direction;
        transform.LookAt(direction);
        //TODO: Might have to take care of speed. maybe in the set next waypoint. We might get a speed that varies too much depending on the distance between the waypoints.



    }

    void SetNextWaypoint()
    {
        actualWayPoint += 1;
        if (actualWayPoint >= wayPoints.Length ||isBoosting.value == false)
        {
            //end of line, destroy
            gameObject.GetComponent<SurfControl>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            return;
        }
        targetWaypointVectorPosition = wayPoints[actualWayPoint].wayPoint.position;
        isMoving = true;
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

    Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
    {
        Vector3 vVector1 = vPoint - vA;
        Vector3 vVector2 = (vB - vA).normalized;

        var d = Vector3.Distance(vA, vB);
        var t = Vector3.Dot(vVector2, vVector1);

        if (t <= 0)
            return vA;

        if (t >= d)
            return vB;

        Vector3 vVector3 = vVector2 * t;

        Vector3 vClosestPoint = vA + vVector3;

        return vClosestPoint;
    }

    WaipointAndIndex findClosestWayPoints(WayPoints[] wayPointList)
    {

        Debug.Log("should Only be call on start");
        WaipointAndIndex result = new WaipointAndIndex();
        Vector3 intersectPoint;
        float distanceMini = 0.0f;
        int closestWaypointIndex = 0;
        for ( int i = 0; i<= wayPointList.Length - 1; i++)
        {
            Vector3 vA = wayPointList[i].wayPoint.position;
            Transform nexWaypoint;
            if (i < wayPointList.Length - 1) { 
                nexWaypoint = wayPointList[i + 1].wayPoint;
            }
            else { 
                nexWaypoint = wayPointList[i - 1].wayPoint;
            }
            Vector3 vB = nexWaypoint.transform.position;

            intersectPoint = ClosestPointOnLine(vA, vB, gameObject.transform.position);
            float dist = Vector3.Distance(intersectPoint, gameObject.transform.position);

            if (distanceMini == 0.0f)
            {
                distanceMini = dist;
                closestWaypointIndex = i;
            }
           
            if(distanceMini > dist)
            {
                distanceMini = dist;
                closestWaypointIndex = i;
            }
        }

        result.theWaypoint = wayPointList[closestWaypointIndex].wayPoint.position;
        result.index = closestWaypointIndex;
        return result;
    }
}
