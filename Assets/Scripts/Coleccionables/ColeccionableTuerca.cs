using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColeccionableTuerca : MonoBehaviour
{
    public Text textTuerca;
    AudioSource audioPick;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        GameManager.Instance.SetPlayerTuerca(0);
        audioPick = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        textTuerca.text = "" + GameManager.Instance.GetPlayerTuerca();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManager.SeleccionAudio(0, 0.5f);
            GameManager.Instance.IncreasePlayerTuerca(1);
            Destroy(gameObject);
            audioPick.Play();
        }
    }
}
