using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionablePintura : MonoBehaviour
{
    GameManager gamemanager;
    public Text textPintura;
    AudioSource audioPick;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.pintura = 0;
        audioPick = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManager.SeleccionAudio(2, 0.5f);
            gamemanager.pintura++;
            Destroy(gameObject);
            textPintura.text = "" + gamemanager.pintura;
        }

    }
}
