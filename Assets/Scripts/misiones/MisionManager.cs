using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionManager : MonoBehaviour
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

    GameObject currentDestination;

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

        maxVectors = 5;

        endPosition = new Vector2[maxVectors];

        endPosition[0] = new Vector2(1112f, -522f);
        endPosition[1] = new Vector2(1312f, -118f);
        endPosition[2] = new Vector2(650f, -663f);
        endPosition[3] = new Vector2(125f, -1063f);
        endPosition[4] = new Vector2(89f, 177f);
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
        currentDestination = Instantiate(endPrefab, endPosition[numrandom], Quaternion.identity);

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

    public void EndMission()
    {
        timer.SetActive(false);
        gpsArrow.SetActive(false);
        Debug.Log("Mision finalizada");

        activeMision = false;

        Destroy(currentDestination);
        
    }
}
