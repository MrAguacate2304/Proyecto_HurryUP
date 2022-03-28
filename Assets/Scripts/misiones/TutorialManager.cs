using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject message1, message2, message3;

    void Start()
    {
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
    }

    public void showMessage1()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(true);
        message2.SetActive(false);
        message3.SetActive(false);
    }
    public void showMessage2()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(true);
        message3.SetActive(false);
    }
    public void showMessage3()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(true);
    }
    public void hideMessages()
    {
        GameManager.Instance.ResumeGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
    }
}
