using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject credits;
    public GameObject coverPage;

    void Start()
    {
        credits.SetActive(false);

        if (!GameManager.Instance.introduction) { coverPage.SetActive(true); }
        else { coverPage.SetActive(false); }
    }

    public void openMainMenu()
    {
        this.gameObject.SetActive(true);
        credits.SetActive(false);
    }

    public void openCredits()
    {
        credits.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void openOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void playGame()
    {
        SceneManager.LoadScene("In_Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
