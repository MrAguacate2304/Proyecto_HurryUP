using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMenu : MonoBehaviour
{
    public MisionManager mManager;

    public void Sleep()
    {
        if (GameManager.Instance.night)
        {
            GameManager.Instance.night = false;
        }
    }

    public void TutoStepComplete()
    {
        if (!GameManager.Instance.tutorialFinished){
            mManager.TutoNextStep(); 
        } 
    }
}