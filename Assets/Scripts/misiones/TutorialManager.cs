using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public GameObject message1, message2, message3, message4, message5, message6;

    void Start()
    {
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
        message4.SetActive(false);
        message5.SetActive(false);
        message6.SetActive(false);
    }

    public void showMessage1()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(true);
        message2.SetActive(false);
        message3.SetActive(false);
        message4.SetActive(false);
        message5.SetActive(false);
        message6.SetActive(false);
    }
    public void showMessage2()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(true);
        message3.SetActive(false);
        message4.SetActive(false);
        message5.SetActive(false);
        message6.SetActive(false);
    }
    public void showMessage3()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(true);
        message4.SetActive(false);
        message5.SetActive(false);
        message6.SetActive(false);
    }
    public void showMessage4()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
        message4.SetActive(true);
        message5.SetActive(false);
        message6.SetActive(false);
    }
    public void showMessage5()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
        message4.SetActive(false);
        message5.SetActive(true);
        message6.SetActive(false);
    }
    public void showMessage6()
    {
        GameManager.Instance.PauseGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
        message4.SetActive(false);
        message5.SetActive(false);
        message6.SetActive(true);
    }
    public void hideMessages()
    {
        GameManager.Instance.ResumeGame();
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);
        message4.SetActive(false);
        message5.SetActive(false);
        message6.SetActive(false);
    }

    public void loadGame()
    {
        GameManager.Instance.ResumeGame();
        SceneManager.LoadScene("In_Game");
    }
}
