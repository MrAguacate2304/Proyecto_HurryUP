using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : MonoBehaviour
{
    public float maxSpeed = 0;

    public float minDistanceToReachWaypoint = 20;

    public WaypointNode[] nextWaypointNode;

    private void Start()
    {
        if (nextWaypointNode.Length == 0)
            Debug.LogError($"Waypoint {gameObject.name} is missing a nextWaypointNode. Please assign one in the inspector");
        else
        {
            foreach (WaypointNode waypoint in nextWaypointNode)
            {
                if (waypoint == null)
                    Debug.LogError($"Waypoint {gameObject.name} has an empty nextWaypointNode. Please assign one in the inspector");
            }
        }
    }
}
