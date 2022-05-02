using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool gamePaused;

    int playerXP;
    int playerCoins;

    [HideInInspector] public bool introduction;
    [HideInInspector] public bool night;

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

        introduction = false;
        night = false;
        bikeSpriteID = 0;
        exhaustSprite = false;
    }


    void Update()
    {
        
    }


    public void IncreasePlayerXP(int value) { playerXP += value; }
    public void IncreasePlayerCoins(int value) { playerCoins += value; }
    public int GetPlayerXP() { return playerXP; }
    public int GetPlayerCoins() { return playerCoins; }

    public void SetBikeSpriteID(int value) { bikeSpriteID = value; }
    public void SetExhaustSpriteID(bool value) { exhaustSprite = value; }
    public int GetBikeSpriteID() { return bikeSpriteID; }
    public bool GetExhaustSpriteID() { return exhaustSprite; }

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
