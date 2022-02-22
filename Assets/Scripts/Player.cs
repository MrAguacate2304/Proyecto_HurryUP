using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Bike Settings")]

    public float playerAcceleration = 10.0f;
    public float turnFactor = 3.5f;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    Rigidbody2D rb2d;
    Mision_Manager mision_manager;

    void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //mision_manager = GameObject.FindGameObjectWithTag("Destination").GetComponent<Mision_Manager>();
        //mision_manager.startRandPos(gameObject);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * playerAcceleration * playerAcceleration;

        rb2d.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        rotationAngle -= steeringInput * turnFactor;

        rb2d.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(mision_manager.tag == "Empresa")
        {
            mision_manager.randPos();
        }
    }
}
