using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInputHandler : MonoBehaviour
{
    [Header("Bike Settings")]

    public float accelerationFactor = 35f;
    public float turnFactor = 3.5f;
    public float max_counter = 5;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;
    //float steeringAmount;

    Rigidbody2D carRigidbody2D;

    bool playerCollision = false;
    bool stoped = false;
    float counter;


    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (!playerCollision && stoped)
        {
            counter += Time.fixedDeltaTime;
            if (counter > max_counter)
            {
                stoped = false;
                counter = 0;
            }
        }

        if (!playerCollision && !stoped) { ApplyEngineForce(); }

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 2);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        carRigidbody2D.MoveRotation(rotationAngle);

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public float GetVelocityMagnitude()
    {
        return carRigidbody2D.velocity.magnitude;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCollision = true;
            stoped = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCollision = false;
        }
    }

}