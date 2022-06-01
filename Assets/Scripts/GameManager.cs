using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool gamePaused;

    int playerXP;
    int playerCoins;

    [HideInInspector] public int tuerca;
    [HideInInspector] public int pintura;

    [HideInInspector] public bool tutorialFinished = false;
    [HideInInspector] public int tutorialMission = 1;
    [HideInInspector] public bool introduction;
    [HideInInspector] public bool night;

    int engineLvl;
    int bikeSpriteID;
    bool exhaustSprite;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        gamePaused = false;

        tutorialFinished = false;
        tutorialMission = 1;

        introduction = false;
        night = false;

        bikeSpriteID = 0;
        exhaustSprite = false;
        engineLvl = 0;
    }


    void Update()
    {
        
    }


    public void IncreasePlayerXP(int value) { playerXP += value; }
    public void IncreasePlayerCoins(int value) { playerCoins += value; }
    public void IncreasePlayerTuerca (int value) { tuerca += value; }
    public void IncreasePlayerPintura(int value) { pintura += value; }

    public int GetPlayerXP() { return playerXP; }
    public int GetPlayerCoins() { return playerCoins; }
    public int GetPlayerTuerca() { return tuerca; }
    public int GetPlayerPintura() { return pintura; }

    public void SetBikeSpriteID(int value) { bikeSpriteID = value; }
    public void SetExhaust(bool value) { exhaustSprite = value; }
    public void SetEngineLvl(int value) { engineLvl = value; }

    public int GetEngineLvl() { return engineLvl; }
    public int GetBikeSpriteID() { return bikeSpriteID; }
    public bool GetExhaust() { return exhaustSprite; }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }

    public bool GetGamePausedBool() { return gamePaused; }
}
