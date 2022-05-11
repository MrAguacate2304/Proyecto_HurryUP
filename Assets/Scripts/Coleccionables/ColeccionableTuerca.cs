using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionableTuerca : MonoBehaviour
{
    GameManager gamemanager;
    //public Text textTuerca;
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.tuerca = 0;
        //textTuerca.text = "" + gamemanager.tuerca;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamemanager.tuerca++;
            Debug.Log(gamemanager.tuerca);
            Destroy(gameObject);
        }

    }
}
