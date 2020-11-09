using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Waypoint[] waypoints;


    /// <summary>
    /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen.
    /// </summary>
    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            waypoints = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<Path>().waypoints;
        }
    }
    public Waypoint GetNextWaypoint(int i)
    {
        return waypoints[i + 1];
    }
}

