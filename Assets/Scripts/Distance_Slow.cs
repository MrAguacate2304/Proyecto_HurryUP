using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Slow : MonoBehaviour
{
    private BoxCollider2D col;

    TopDownCarController topDownCarController;

    public GameObject car;

    void Awake()
    {
        topDownCarController = car.GetComponent<TopDownCarController>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "IA")
        {
            topDownCarController.accelerationFactor = topDownCarController.accelerationFactor / 2;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "IA")
        {
            topDownCarController.accelerationFactor = topDownCarController.accelerationFactor * 2;        
        }
    }  
}
