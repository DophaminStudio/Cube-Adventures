using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

class MoveAcrossWaypoint : MonoBehaviour
{
    public WaypointCircuit mainWaypoint;
    public Vector3[] waypoints; //множество точек маршрута 
    public bool lookAtWp = true;
    public float speed = 1.0f; //скорость движения 
    int currentRoutePoint = 0; //текущий индекс пути 

    void Update()
    {
        if (lookAtWp)
        {
            transform.LookAt(mainWaypoint.waypointList.items[currentRoutePoint].transform);
        }
        if (transform.position == mainWaypoint.waypointList.items[currentRoutePoint].transform.position)
        {
            currentRoutePoint++;
            if (currentRoutePoint == mainWaypoint.waypointList.items.Length)
            {
                currentRoutePoint--;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, mainWaypoint.waypointList.items[currentRoutePoint].transform.position, speed);
    }

}
