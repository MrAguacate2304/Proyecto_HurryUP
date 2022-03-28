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

    SpriteRenderer pSpriteRenderer;
    public Sprite pNormal, pWorking;

    int numrandom = 0;

    bool activeMision;
    bool activeObjective;
    int nObjectives;

    GameObject currentDestination;

    public GameObject tutorialGO;
    TutorialManager tutoManager;
    bool tutorial = false;
    int tutorialObjective = 0;
    Vector2[] tutoPosition;

    private void Awake()
    {
        activeMision = false;
        activeObjective = false;

        timer = GameObject.FindGameObjectWithTag("timer");
        timer.SetActive(false);

        gpsArrow = GameObject.FindGameObjectWithTag("gpsArrow");
        gpsArrow.SetActive(false);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pSpriteRenderer = player.GetComponent<SpriteRenderer>();
        timerController = timer.GetComponent<TimerController>();

        arrowRb = gpsArrow.GetComponent<Rigidbody2D>();

        tutoManager = tutorialGO.GetComponent<TutorialManager>();

        maxVectors = 11;

        endPosition = new Vector2[maxVectors];

        endPosition[0] = new Vector2(1112f, -522f);
        endPosition[1] = new Vector2(1312f, -118f);
        endPosition[2] = new Vector2(650f, -663f);
        endPosition[3] = new Vector2(125f, -1063f);
        endPosition[4] = new Vector2(89f, 177f);
        endPosition[5] = new Vector2(1317f, 206f);
        endPosition[6] = new Vector2(849f, -179f);
        endPosition[7] = new Vector2(29f, -862f);
        endPosition[8] = new Vector2(637f, -1252f);
        endPosition[9] = new Vector2(-185f, -1236f);
        endPosition[10] = new Vector2(1286f, -698f);


        tutoPosition = new Vector2[4];
        tutoPosition[0] = new Vector2(80f, 0f);
        tutoPosition[1] = new Vector2(-180f, 100f);
        tutoPosition[2] = new Vector2(13f, 180f);
        tutoPosition[3] = new Vector2(360f, 860f);
    }


    void Update()
    {
        if (activeMision)
        {
            pSpriteRenderer.sprite = pWorking;

            if (activeObjective) { RotateArrow(); }

            if (nObjectives > 0 && !activeObjective)
            {
                StartMission();
            }
            else if (nObjectives <= 0)
            {
                EndMission();
            }
        }
        else
        {
            pSpriteRenderer.sprite = pNormal;
        }

        if (tutorial)
        {
            pSpriteRenderer.sprite = pWorking;
            gpsArrow.SetActive(true);

            if (activeObjective) { RotateArrow(); }
            
            if (tutorialObjective == 0 && !activeObjective) {
                tutoManager.showMessage1();
                currentDestination = Instantiate(endPrefab, tutoPosition[tutorialObjective], Quaternion.identity);
                activeObjective = true;
            }
            else if (tutorialObjective == 1 && !activeObjective) {
                tutoManager.showMessage2();
                currentDestination = Instantiate(endPrefab, tutoPosition[tutorialObjective], Quaternion.identity);
                activeObjective = true;
            }
            else if (tutorialObjective == 2 && !activeObjective) {
                currentDestination = Instantiate(endPrefab, tutoPosition[tutorialObjective], Quaternion.identity);
                activeObjective = true;
            }
            else if (tutorialObjective == 3 && !activeObjective) {
                tutoManager.showMessage3();
                currentDestination = Instantiate(endPrefab, tutoPosition[tutorialObjective], Quaternion.identity);
                activeObjective = true;
            }
            else if (tutorialObjective < 0 || tutorialObjective > 3) { 
                tutorial = false;
            }

        }
        else
        {
            pSpriteRenderer.sprite = pNormal;
            gpsArrow.SetActive(false);
        }
    }

    public void StartMission()
    {
        activeObjective = true;

        timer.SetActive(true);
        gpsArrow.SetActive(true);

        numrandom = Random.Range(0, maxVectors);
        Debug.Log(numrandom);
        currentDestination = Instantiate(endPrefab, endPosition[numrandom], Quaternion.identity);

        SetTimer();
    }

    public void Init5ObjectiveMission()
    {
        if (!activeMision) 
        {
            nObjectives = 5;
            activeMision = true;
            activeObjective = false;
        }
    }

    public void Init10ObjectiveMission()
    {
        if (!activeMision)
        {
            nObjectives = 10;
            activeMision = true;
            activeObjective = false;
        }
    }

    public void Init15ObjectiveMission()
    {
        if (!activeMision)
        {
            nObjectives = 15;
            activeMision = true;
            activeObjective = false;
        }
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
        Vector2 direction = new Vector2(currentDestination.transform.position.x, currentDestination.transform.position.y) - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowRb.rotation = angle - 90;
    }

    public void EndObjective()
    {
        Debug.Log("Objetivo alcalnzado");
        Destroy(currentDestination);
        if (activeMision) { nObjectives--; }
        else if (tutorial) { tutorialObjective++; }
        activeObjective = false;
    }

    void EndMission()
    {
        timer.SetActive(false);
        gpsArrow.SetActive(false);

        activeMision = false;
    }

    public void StartTutorial()
    {
        tutorial = true;
        tutorialObjective = 0;
    }

}
