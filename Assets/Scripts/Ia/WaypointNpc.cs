using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNpc : MonoBehaviour
{
    public float maxSpeed = 0;

    public float minDistanceToReachWaypoint = 20;

    public WaypointNpc[] nextWaypointNpc;

    private void Start()
    {
        if (nextWaypointNpc.Length == 0)
            Debug.LogError($"Waypoint {gameObject.name} is missing a nextWaypointNode. Please assign one in the inspector");
        else
        {
            foreach (WaypointNpc waypoint in nextWaypointNpc)
            {
                if (waypoint == null)
                    Debug.LogError($"Waypoint {gameObject.name} has an empty nextWaypointNode. Please assign one in the inspector");
            }
        }
    }
}