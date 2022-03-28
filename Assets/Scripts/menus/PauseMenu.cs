using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public void ResetScene()
    {
        GameManager.Instance.ResumeGame();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OpenMainMenu()
    {
        GameManager.Instance.ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

}
