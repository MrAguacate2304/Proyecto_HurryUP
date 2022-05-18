using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{

    public int velocity;
    public GameObject player;
    public int radioDeteccion;
    bool persec;


    // Start is called before the first frame update
    void Start()
    {
        persec = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (persec)
        {

        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            persec = true;
        }
        else
        {
            persec = false;
        }
    }

}
