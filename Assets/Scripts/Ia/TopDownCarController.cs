using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    [Header("Bike Settings")]

    public float accelerationFactor = 35f;
    public float turnFactor = 3.5f;
    public float maxCounter = 5f;

    public PlayerController player;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;
    //float steeringAmount;

    Rigidbody2D carRigidbody2D;
    BoxCollider2D carBoxCollider2D;

    bool playerCollision = false;
    bool stoped = false;
    float counter;
    //audio
    AudioSource audioBeep;

    void Awake ()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
        carBoxCollider2D = GetComponent<BoxCollider2D>();
        audioBeep = GetComponent<AudioSource>();
        
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate()
    {
        if (!playerCollision && stoped)
        {
            counter += Time.fixedDeltaTime;
            if (counter > maxCounter)
            {
                
                if (gameObject.tag == "Npc")
                {
                    Destroy(gameObject);
                }
                else
                {
                    stoped = false;
                    counter = 0;
                }
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioBeep.Play();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Player") && player.isMoving == true)
        {
            playerCollision = true;
            stoped = true;
            //audio
            
            if (gameObject.tag == "Npc")
            {
                carBoxCollider2D.isTrigger = true;
            }
        }
        
        if (other.gameObject.tag == "Car")
        {
            playerCollision = true;
            stoped = true;

            if (gameObject.tag == "Npc")
            {
                carBoxCollider2D.isTrigger = true;
            }
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
