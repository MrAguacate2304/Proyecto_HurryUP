using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puntoInteres : MonoBehaviour
{
    public GameObject menu;

    public MisionManager misionManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!GameManager.Instance.tutorialFinished)
        {
            if (misionManager.tutorialStep == 1 && menu.tag == "company")
            {
                if (other.tag == "Player")
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        GameManager.Instance.PauseGame();
                        menu.SetActive(true);
                    }
                }
            }
            else if (misionManager.tutorialStep == 4 && menu.tag == "garage")
            {
                if (other.tag == "Player")
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        GameManager.Instance.PauseGame();
                        menu.SetActive(true);
                    }
                }
            }
            else if (misionManager.tutorialStep == 6 && menu.tag == "house")
            {
                if (other.tag == "Player")
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        GameManager.Instance.PauseGame();
                        menu.SetActive(true);
                    }
                }
            }
        }
        else
        {
            if (menu.tag == "company" || menu.tag == "garage")
            {
                if (!GameManager.Instance.night)
                {
                    if (other.tag == "Player")
                    {
                        if (Input.GetKey(KeyCode.E))
                        {
                            GameManager.Instance.PauseGame();
                            menu.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                if (other.tag == "Player")
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        GameManager.Instance.PauseGame();
                        menu.SetActive(true);
                    }
                }
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
