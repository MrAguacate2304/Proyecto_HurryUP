using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BocaIncendios : MonoBehaviour
{
    AudioSource crashAudio;
    void Start()
    {
        crashAudio = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { crashAudio.Play(); }
    }
}
