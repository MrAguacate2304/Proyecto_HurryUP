using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision_Manager : MonoBehaviour
{
    public GameObject endPrefab;

    Vector2[] endPosition;
    int maxVectors;

    GameObject timer;
    TimerController timerController;
    GameObject gpsArrow;
    Rigidbody2D arrowRb;

    GameObject player;

    int numrandom = 0;

    bool activeMision;

    private void Awake()
    {
        activeMision = false;

        timer = GameObject.FindGameObjectWithTag("timer");
        timer.SetActive(false);

        gpsArrow = GameObject.FindGameObjectWithTag("gpsArrow");
        gpsArrow.SetActive(false);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timerController = timer.GetComponent<TimerController>();

        arrowRb = gpsArrow.GetComponent<Rigidbody2D>();

        maxVectors = 3;

        endPosition = new Vector2[maxVectors];

        endPosition[0] = new Vector2(150f, 212f);
        endPosition[1] = new Vector2(525f, -1070f);
        endPosition[2] = new Vector2(-240f, -515f);        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !activeMision)
        {
            activeMision = true;
            StartRandomMission();
            timer.SetActive(true);
            gpsArrow.SetActive(true);
        }

        if (activeMision)
        {
            RotateArrow();
        }
    }

    public void StartRandomMission()
    {
        numrandom = Random.Range(0, maxVectors);
        Debug.Log(numrandom);
        Instantiate(endPrefab, endPosition[numrandom], Quaternion.identity);

        SetTimer();
    }

    private void SetTimer()
    {
        int min = 0;
        int sec = 0;

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float distance = Vector2.Distance(playerPos, endPosition[numrandom]);

        while (distance>0)
        {
            sec += 5;
            distance -= 100;
        }

        while (sec >= 60)
        {
            min += 1;
            sec -= 60;
        }

        timerController.StartCount(min, sec);
    }

    void RotateArrow()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 direction = endPosition[numrandom] - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowRb.rotation = angle - 90;
    }
}
