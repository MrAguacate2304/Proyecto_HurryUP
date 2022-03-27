using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public GameObject gMObject;
    public void Close()
    {
        GameManager gameManager = gMObject.GetComponent<GameManager>();
        gameManager.ResumeGame();
        this.gameObject.SetActive(false);
    }
}
