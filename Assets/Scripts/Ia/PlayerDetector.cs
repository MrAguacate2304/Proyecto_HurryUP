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
        if (startTimer)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }

        if (exit)
        {
            
            if (timer >= 2)
            {
                topDownCarController.accelerationFactor = topDownCarController.accelerationFactor * 35f;
                carAiHandler.FolloWayPoints();
                
            }
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            carAiHandler.startFollow = true;
            startTimer = true;

        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("sal");
            timer = 0;
            exit = true;
            carAiHandler.startFollow = false;
        }
    }
}
