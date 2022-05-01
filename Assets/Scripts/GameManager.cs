using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    int playerXP;
    int playerCoins;

    [HideInInspector] public bool introduction;
    [HideInInspector] public bool night;

    public GameObject IaCarsPrefab;

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
        introduction = false;
        night = false;
    }


    void Update()
    {
        
    }


    public void IncreasePlayerXP(int value) { playerXP += value; }
    public void IncreasePlayerCoins(int value) { playerCoins += value; }
    public int GetPlayerXP() { return playerXP; }
    public int GetPlayerCoins() { return playerCoins; }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
