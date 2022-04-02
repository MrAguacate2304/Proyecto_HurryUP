using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NpcAiHandler : MonoBehaviour
{

    [Header("Ai settings")]
    Vector3 targetPosition = Vector3.zero;
    //Transform targetTransform = null;

    float orignalMaximumSpeed = 200;

    WaypointNpc currentWaypoint = null;
    WaypointNpc previousWaypoint = null;
    WaypointNpc[] allWayPoints;

    public float maxSpeed = 200;
    public float skillLevel = 1.0f;

    TopDownCarController topDownCarController;

    // Start is called before the first frame update
    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
        allWayPoints = FindObjectsOfType<WaypointNpc>();

        orignalMaximumSpeed = maxSpeed;
    }

    void Start()
    {
        SetMaxSpeedBasedOnSkillLevel(maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;

        FolloWayPoints();

        inputVector.x = TurnTowardTarget();
        inputVector.y = ApplyThrottleOrBrake(inputVector.x);

        topDownCarController.SetInputVector(inputVector);
    }

    void FolloWayPoints()
    {
        if (currentWaypoint == null)
        {
            currentWaypoint = FindClosestWayPoint();
            previousWaypoint = currentWaypoint;
        }

        if (currentWaypoint != null)
        {
            targetPosition = currentWaypoint.transform.position;

            float distanceToWayPoint = (targetPosition - transform.position).magnitude;

            if (distanceToWayPoint <= currentWaypoint.minDistanceToReachWaypoint)
            {
                if (currentWaypoint.maxSpeed > 0)
                {
                    SetMaxSpeedBasedOnSkillLevel(currentWaypoint.maxSpeed);

                }
                else
                {
                    SetMaxSpeedBasedOnSkillLevel(1000);
                }

                previousWaypoint = currentWaypoint;

                currentWaypoint = currentWaypoint.nextWaypointNpc[Random.Range(0, currentWaypoint.nextWaypointNpc.Length)];
            }
        }
    }

    WaypointNpc FindClosestWayPoint()
    {
        return allWayPoints
         .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
         .FirstOrDefault();

    }

    float TurnTowardTarget()
    {
        Vector2 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();

        float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
        angleToTarget *= -1;

        float steerAmount = angleToTarget / 45.0f;

        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);

        return steerAmount;
    }

    float ApplyThrottleOrBrake(float inputX)
    {

        if (topDownCarController.GetVelocityMagnitude() > maxSpeed) { return 0; }

        float reduceSpeedDueToCornering = Mathf.Abs(inputX) / 1.0f;

        return 1.05f - reduceSpeedDueToCornering * skillLevel;
    }

    void SetMaxSpeedBasedOnSkillLevel(float newSpeed)
    {
        maxSpeed = Mathf.Clamp(newSpeed, 0, orignalMaximumSpeed);

        float skillbasedMaxiumSpeed = Mathf.Clamp(skillLevel, 0.3f, 1.0f);
        maxSpeed = maxSpeed * skillbasedMaxiumSpeed;
    }
}