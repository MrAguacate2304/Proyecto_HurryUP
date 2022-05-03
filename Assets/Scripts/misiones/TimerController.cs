using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMP_Text countText;

    public GameObject mManagerObj;
    MisionManager mManager;

    private float rest;
    private bool counting;
    
    [HideInInspector] public bool lose;
    [HideInInspector] public int restTime;

    private void Start()
    {
        lose = false;

        mManager = mManagerObj.GetComponent<MisionManager>();
    }

    private void Update()
    {
        if (counting)
        {
            rest -= Time.deltaTime;
            restTime = (int)rest;
            if (rest < 1)
            {
                PauseCount();
                if (!GameManager.Instance.tutorialFinished) { TutoCountFinish(); }
                else  { CountFinish(); }
            }
            int tMin = Mathf.FloorToInt(rest / 60);
            int tSec = Mathf.FloorToInt(rest % 60);
            countText.text = string.Format("{00:00}:{01:00}", tMin, tSec);
        }
    }

    public void StartCount(int _min, int _sec)
    {
        rest = (_min * 60) + _sec;

        counting = true;
    }

    public void PauseCount()
    {
        counting = false;
    }

    private void CountFinish()
    {
        lose = true;
        mManager.EndObjective();
        lose = false;
    }

    private void TutoCountFinish()
    {
        lose = true;
        mManager.TutoMissionFinish();
        lose = false;
    }

}
