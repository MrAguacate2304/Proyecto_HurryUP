using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private BoxCollider2D col;
    
    TopDownCarController topDownCarController;
    CarAiHandler carAiHandler;

    public GameObject car;
    
    float timer = 0;
    bool startTimer = false;
    bool exit = false;
    
    void Awake()
    {
        topDownCarController = car.GetComponent<TopDownCarController>();
        carAiHandler = car.GetComponent<CarAiHandler>();
    }
    
    void Update()
    {
    
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            topDownCarController.accelerationFactor = topDownCarController.accelerationFactor * 2f;
            carAiHandler.runOption = 2;
            startTimer = true;

        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            topDownCarController.accelerationFactor = topDownCarController.accelerationFactor / 2f;
            carAiHandler.runOption = 1;
        }
    }
}
