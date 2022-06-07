using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MisionManager : MonoBehaviour
{
    public GameObject endPrefab;

    Vector2[] endPosition;
    int maxVectors;
    int lastPos = -1;

    //GUI
    GameObject timer;
    TimerController timerController;
    GameObject gpsArrow;
    Rigidbody2D arrowRb;
    //Player
    GameObject player;
    public GameObject boxSprite;

    //Normal Missions
    bool activeMision;
    bool activeObjective;
    int nObjectives;
    int currentMaxObjectives;
    int maxCoins;

    //Notifications
    bool notificationShow;
    float notificationTime;
    public GameObject notification;
    public TMP_Text nTitle;
    public TMP_Text nLine1;
    public TMP_Text nLine2;

    //Phone
    public GameObject phone;
    public TMP_Text pTitle, pContent, pReward;
    public GameObject pAccept, pCancell;

    //Tutorial
    [HideInInspector] public int tutorialStep = 0;
    [HideInInspector] public bool activeTutoStep = false;
    float tutorialTimer = 0;
    public GameObject puntoInteresEmpresa;
    public GameObject puntoInteresTaller;
    public GameObject puntoInteresCasa;

    int numrandom = 0;
    GameObject currentDestination;

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

        timerController = timer.GetComponent<TimerController>();
        arrowRb = gpsArrow.GetComponent<Rigidbody2D>();

        tutorialStep = 0;
        activeTutoStep = false;
        tutorialTimer = 0;

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
    }


    void Update()
    {
        
        if (GameManager.Instance.tutorialFinished == false)
        {
            boxSprite.SetActive(false);

            if (tutorialStep == 0 && !activeTutoStep)
            {
                bool bossCall = false;
                tutorialTimer += Time.deltaTime;
                if (tutorialTimer >= 5 && !bossCall)
                {
                    pTitle.text = "JEFE";
                    pContent.text = "Necesito que vengas a trabajar, hay un pedido y tu eres el unico disponible. Corre!";
                    pReward.text = "";
                    pAccept.SetActive(true);
                    pCancell.SetActive(false);
                    phone.SetActive(true);
                    phone.GetComponent<AudioSource>().Play();
                    bossCall = true;
                    activeTutoStep = true;
                    tutorialTimer = 0;
                }
            }
            else if (tutorialStep == 1)
            {
                if (!gpsArrow.activeSelf) { gpsArrow.SetActive(true); }

                currentDestination = puntoInteresEmpresa;
                RotateArrow();

                activeTutoStep = false;
            }
            else if (tutorialStep == 2)
            {
                boxSprite.SetActive(true);
                if (!activeTutoStep)
                {
                    currentDestination = Instantiate(endPrefab, new Vector2(-140, -1255), Quaternion.identity);
                    if (!gpsArrow.activeSelf) { gpsArrow.SetActive(true); }
                    if (!timer.activeSelf) { timer.SetActive(true); }
                    timerController.StartCount(5, 0);
                    activeTutoStep = true;
                }
                RotateArrow();
            }
            else if (tutorialStep == 3 && !activeTutoStep)
            {
                boxSprite.SetActive(false);
                bool bossCall = false;
                tutorialTimer += Time.deltaTime;
                if (tutorialTimer >= 3 && !bossCall)
                {
                    pTitle.text = "JEFE";
                    pContent.text = "Buen trabajo! Antes de volver a trabajar pasate por el taller.";
                    pReward.text = "";
                    pAccept.SetActive(true);
                    pCancell.SetActive(false);
                    phone.SetActive(true);
                    phone.GetComponent<AudioSource>().Play();
                    bossCall = true;
                    activeTutoStep = true;
                    tutorialTimer = 0;
                }
            }
            else if (tutorialStep == 4)
            {
                if (!gpsArrow.activeSelf) { gpsArrow.SetActive(true); }

                currentDestination = puntoInteresTaller;
                RotateArrow();

                activeTutoStep = false;
            }
            else if (tutorialStep == 5 && !activeTutoStep)
            {
                GameManager.Instance.night = true;
                bool bossCall = false;
                tutorialTimer += Time.deltaTime;
                if (tutorialTimer >= 3 && !bossCall)
                {
                    pTitle.text = "MAMA";
                    pContent.text = "Ya es tarde, ahora no puedes trabajar, vuelve a casa a descansar antes de que te pille algun maleante. ";
                    pReward.text = "";
                    pAccept.SetActive(true);
                    pCancell.SetActive(false);
                    phone.SetActive(true);
                    phone.GetComponent<AudioSource>().Play();
                    bossCall = true;
                    activeTutoStep = true;
                    tutorialTimer = 0;
                }
            }
            else if (tutorialStep == 6)
            {
                if (!gpsArrow.activeSelf) { gpsArrow.SetActive(true); }

                currentDestination = puntoInteresCasa;
                RotateArrow();

                activeTutoStep = false;
            }
            else if (tutorialStep == 7 && !activeTutoStep)
            {
                bool bossCall = false;
                tutorialTimer += Time.deltaTime;
                if (tutorialTimer >= 5 && !bossCall)
                {
                    pTitle.text = "JEFE";
                    pContent.text = "Ayer fue un dia duro. Pero hoy toca trabajar mas. Cuando puedas pasate por la empresa y empieza una jornada de trabajo.";
                    pReward.text = "";
                    pAccept.SetActive(true);
                    pCancell.SetActive(false);
                    phone.SetActive(true);
                    phone.GetComponent<AudioSource>().Play();
                    bossCall = true;
                    activeTutoStep = true;
                    tutorialTimer = 0;
                }
            }
            else if (tutorialStep >= 8)
            {
                GameManager.Instance.tutorialFinished = true;
            }

        }
        else if (activeMision)
        {
            boxSprite.SetActive(true);

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
            boxSprite.SetActive(false);
            gpsArrow.SetActive(false);
        }

        //hide notification
        if (notificationShow)
        {
            notificationTime += Time.deltaTime;
            if (notificationTime > 5)
            {
                notification.SetActive(false);
                notificationShow = false;
                notificationTime = 0;
            }
        }
    }

    public void StartMission()
    {
        activeObjective = true;

        timer.SetActive(true);
        gpsArrow.SetActive(true);

        numrandom = Random.Range(0, maxVectors);
        if(numrandom == lastPos && numrandom < maxVectors/2) { numrandom += 1; }
        else if (numrandom == lastPos && numrandom > maxVectors / 2) { numrandom -= 1; }
        currentDestination = Instantiate(endPrefab, endPosition[numrandom], Quaternion.identity);

        SetTimer();
    }

    public void Init5ObjectiveMission()
    {
        if (!activeMision) 
        {
            nObjectives = 3;
            currentMaxObjectives = 3;
            maxCoins = 100;
            activeMision = true;
            activeObjective = false;
        }
    }

    public void Init10ObjectiveMission()
    {
        if (!activeMision)
        {
            nObjectives = 6;
            currentMaxObjectives = 6;
            maxCoins = 300;
            activeMision = true;
            activeObjective = false;
        }
    }

    public void Init15ObjectiveMission()
    {
        if (!activeMision)
        {
            nObjectives = 10;
            currentMaxObjectives = 10;
            maxCoins = 500;
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
            sec += 6;           //segundos
            distance -= 100;    //metros
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
        if (timerController.lose)
        {
            nTitle.text = "ENTREGA PERDIDA";
            nLine1.text = "0 XP";
            nLine2.text = "-15 $";
            notification.SetActive(true);
            notificationShow = true;
            maxCoins -= 15;
        }
        else if (!timerController.lose)
        {
            //mensaje objetivo alcanzado
            nTitle.text = "ENTREGA EXITOSA";
            nLine1.text = ((currentMaxObjectives - nObjectives) + 1) + " / " + currentMaxObjectives;
            nLine2.text = "+" + timerController.restTime + " XP";
            notification.SetActive(true);
            notificationShow = true;
            GameManager.Instance.IncreasePlayerXP(timerController.restTime);
        }
        Destroy(currentDestination);
        if (activeMision) { nObjectives--; }
        activeObjective = false;
    }

    void EndMission()
    {
        timer.SetActive(false);
        gpsArrow.SetActive(false);

        activeMision = false;
        //mostrar mensaje fin mision +recompensa
        nTitle.text = "JORNADA FINALIZADA";
        nLine1.text = "+50 XP";
        nLine2.text = "+" + maxCoins + " $";
        notification.SetActive(true);
        notificationShow = true;
        GameManager.Instance.IncreasePlayerCoins(maxCoins);
        GameManager.Instance.IncreasePlayerXP(50);
    }

    public void TutoNextStep()
    {
        gpsArrow.SetActive(false);
        timer.SetActive(false);
        tutorialStep++;
        activeTutoStep = false;
        phone.SetActive(false);
    }

    public void TutoMissionFinish()
    {
        if (timerController.lose)
        {
            Destroy(currentDestination);
            gpsArrow.SetActive(false);
            timer.SetActive(false);
            pTitle.text = "JEFE";
            pContent.text = "No has llegado a tiempo! Vuelve a la empresa y intentalo de nuevo.";
            pReward.text = "";
            pAccept.SetActive(true);
            pCancell.SetActive(false);
            phone.SetActive(true);
            phone.GetComponent<AudioSource>().Play();
            activeTutoStep = true;
            tutorialStep = 0;
        }
        else if (!timerController.lose)
        {
            Destroy(currentDestination);
            gpsArrow.SetActive(false);
            timer.SetActive(false);

            GameManager.Instance.tutorialMission++;

            activeTutoStep = false;
            tutorialStep++;
        }
    }

}