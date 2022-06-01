using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionableTuerca : MonoBehaviour
{
    GameManager gamemanager;
    public Text textTuerca;
    AudioSource audioPick;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.tuerca = 0;
        audioPick = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManager.SeleccionAudio(0, 0.5f);
            gamemanager.tuerca++;
            Destroy(gameObject);
            audioPick.Play();
            textTuerca.text = "" + gamemanager.tuerca;
        }

    }
}
