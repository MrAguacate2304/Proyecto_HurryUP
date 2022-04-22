using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Die : MonoBehaviour
{

    public UnityEvent myEvent;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" )
        {
            if (myEvent == null)
            {
                print("myEventCollisionOnEnter was triggered but myEvent was null");
            }
            else
            {
                print("Active" + myEvent);
                myEvent.Invoke();
            }
        }
        
    }
}
