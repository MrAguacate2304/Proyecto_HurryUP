using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionablePintura : MonoBehaviour
{
    GameManager gamemanager;
    //public Text textTuerca;
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.pintura = 0;
        //textTuerca.text = "" + gamemanager.tuerca;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamemanager.pintura++;
            Debug.Log(gamemanager.pintura);
            Destroy(gameObject);
        }

    }
}
