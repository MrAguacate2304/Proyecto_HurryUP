using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puntoInteres : MonoBehaviour
{
    public GameObject gMObject;
    public GameObject menu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) {
                GameManager gameManager = gMObject.GetComponent<GameManager>();
                gameManager.PauseGame();
                menu.SetActive(true);
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
