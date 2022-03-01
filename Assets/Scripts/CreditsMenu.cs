using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsMenu : MonoBehaviour
{
    public int indexScene;



    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
