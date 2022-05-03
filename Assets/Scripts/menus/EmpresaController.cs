using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpresaController : MonoBehaviour
{
    public GameObject mission1, mission2, mission3, tutorial;

    private void Update()
    {
        if (!GameManager.Instance.tutorialFinished)
        {
            if (GameManager.Instance.tutorialMission == 1)
            {
                mission1.SetActive(false);
                mission2.SetActive(false);
                mission3.SetActive(false);
                tutorial.SetActive(true);
            }
            else
            {
                mission1.SetActive(false);
                mission2.SetActive(false);
                mission3.SetActive(false);
                tutorial.SetActive(false);
            }
        }
        else
        {
            mission1.SetActive(true);
            mission2.SetActive(true);
            mission3.SetActive(true);
            tutorial.SetActive(false);
        }
    }
}
