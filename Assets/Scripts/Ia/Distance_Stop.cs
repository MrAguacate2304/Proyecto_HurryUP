using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Stop : MonoBehaviour
{
    TopDownCarController topDownCarController;

    public GameObject car;

    void Awake()
    {
        topDownCarController = car.GetComponent<TopDownCarController>();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "IA")
        {
            topDownCarController.accelerationFactor = topDownCarController.accelerationFactor / 5000;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "IA")
        {
            topDownCarController.accelerationFactor = topDownCarController.accelerationFactor * 5000;
        }
    }
}
