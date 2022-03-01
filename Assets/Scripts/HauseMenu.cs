using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HauseMenu : MonoBehaviour
{
    

    public void PlayGame()
    {
        SceneManager.LoadScene("In_Game");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!");
    }
}
