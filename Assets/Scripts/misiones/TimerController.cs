using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMP_Text countText;

    private float rest;
    private bool counting;
    
    [HideInInspector] public bool lose;

    private void Awake()
    {
        lose = false;
    }

    private void Update()
    {
        if (counting)
        {
            rest -= Time.deltaTime;
            if (rest < 1)
            {
                PauseCount();
                CountFinish();
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
        Debug.Log("se acabo el tiempo");
        lose = true;
    }

}
