using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionablePintura : MonoBehaviour
{
    public Text textPintura;
    AudioSource audioPick;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        GameManager.Instance.SetPlayerPintura(0);
        audioPick = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        textPintura.text = "" + GameManager.Instance.GetPlayerPintura();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManager.SeleccionAudio(2, 0.5f);
            GameManager.Instance.IncreasePlayerPintura(1);
            Destroy(gameObject);
            
        }
    }
}
