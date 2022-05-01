using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject coverPage;
    public GameObject tutorialMessage;

    void Start()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        tutorialMessage.SetActive(false);

        if (!GameManager.Instance.introduction) { coverPage.SetActive(true); }
        else { coverPage.SetActive(false); }
    }

    public void openMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        tutorialMessage.SetActive(false);
    }

    public void openCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
        tutorialMessage.SetActive(false);
    }

    public void openOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void playGame()
    {
        tutorialMessage.SetActive(true);
        credits.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("In_Game");
    }
}
