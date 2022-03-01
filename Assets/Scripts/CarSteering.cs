using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering : MonoBehaviour
{

	Rigidbody2D rb;

	[SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;

	float charcoTimer;
	bool charco;
	float desaceleration = 0;

	public GameObject mManager;

	MisionManager misionManager;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		misionManager = mManager.GetComponent<MisionManager>();

		this.gameObject.transform.position = new Vector2(1255, -1150);

		charco = false;
		charcoTimer = 0;
	}

	void Update()
    {
		if (charco)
        {
			charcoTimer += Time.deltaTime;
            if (charcoTimer > 1)
            {
				charco = false;
				charcoTimer = 0;
				DesRelentizar();
            }
        }
    }
	// Update is called once per frame
	void FixedUpdate()
	{

		steeringAmount = -Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical") > 0)
        {
			speed = Input.GetAxis("Vertical") * (accelerationPower - desaceleration);
        }
        else
        {
			speed = Input.GetAxis("Vertical") * (accelerationPower - desaceleration) * 0.2f;
		}
		direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

		rb.AddRelativeForce(Vector2.up * speed);

		rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

	}
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
			misionManager.EndMission();
        }
        else if (collision.tag == "charco")
        {
			charco = true;
			Relentizar();
        }
    }

	void Relentizar()
    {
		desaceleration = accelerationPower / 1.1f;

	}

	void DesRelentizar()
    {
		desaceleration = 0f;
	}


}