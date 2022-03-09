using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    Vector3 startPos;
    float timer;
    public float resetTime = 3;

    private Rigidbody2D rb;


    void Start()
    {
        startPos = this.gameObject.transform.position;
        timer = 0;
    }

    void Update()
    {

        if (this.gameObject.transform.position.x != startPos.x || this.gameObject.transform.position.y != startPos.y)
        {
            timer += Time.deltaTime;
            if (timer >= resetTime)
            {
                this.transform.position = startPos;
                timer = 0;
                rb.velocity = new Vector2(0, 0);
                
            }
        }
    }
}
