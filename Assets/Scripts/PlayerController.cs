using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

	public bool isMoving = false;

	public GameObject mManager;
	MisionManager misionManager;

	public GameObject miniMapWindow;
	public GameObject mapWindow;
	public GameObject mapIcon;
	public GameObject PauseWindow;
	bool mapOpen = false;
	bool pause = false;
	

	public GameObject spawnPoint;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		misionManager = mManager.GetComponent<MisionManager>();

		Vector2 spawnPos = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y);

		this.gameObject.transform.position = new Vector3(spawnPos.x, spawnPos.y, this.transform.position.z);

		charco = false;
		charcoTimer = 0;

		mapOpen = false;
		mapWindow.SetActive(false);
		mapIcon.SetActive(false);
	}

	void Update()
    {
		isMoving = false;

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

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!mapOpen)
            {
				miniMapWindow.SetActive(false);
				mapIcon.SetActive(true);
				mapWindow.SetActive(true);
				mapOpen = true;
            }
            else if (mapOpen)
            {
				miniMapWindow.SetActive(true);
				mapIcon.SetActive(false);
				mapWindow.SetActive(false);
				mapOpen = false;
			}
        }
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pause)
			{
				OpenPauseMenu();
			}
			else if (pause)
			{
				ClosePauseMenu();
			}
		}
	}

	void FixedUpdate()
	{

		steeringAmount = -Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical") > 0)
        {
			speed = Input.GetAxis("Vertical") * (accelerationPower - desaceleration);
			isMoving = true;

		}
        else
        {
			speed = Input.GetAxis("Vertical") * (accelerationPower - desaceleration) * 0.2f;
			isMoving = true;
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
			misionManager.EndObjective();
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
    public void OpenPauseMenu()
    {
        GameManager.Instance.PauseGame();
        miniMapWindow.SetActive(false);
        PauseWindow.SetActive(true);
        pause = true;
    }
    public void ClosePauseMenu()
    {
        GameManager.Instance.ResumeGame();
        miniMapWindow.SetActive(true);
        PauseWindow.SetActive(false);
        pause = false;
    }

}