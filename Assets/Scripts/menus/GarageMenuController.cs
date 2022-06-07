using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GarageMenuController : MonoBehaviour
{
    public MisionManager mManager;

    public GameObject bikeSprite;
    public Sprite[] bikeSprites;
    public GameObject engineSprite;
    public Sprite[] engineSprites;

    public GameObject tuercasMsg;
    public GameObject pinturaMsg;
    float timerMsg;

    private void Start()
    {
        tuercasMsg.SetActive(false);
        pinturaMsg.SetActive(false);
        timerMsg = 0;
    }

    private void Update()
    {
        bikeSprite.GetComponent<Image>().sprite = bikeSprites[GameManager.Instance.GetBikeSpriteID()];

        if (GameManager.Instance.GetEngineLvl() < 0 || GameManager.Instance.GetEngineLvl() > 2){
            GameManager.Instance.SetEngineLvl(3);
        }
        else {
            engineSprite.GetComponent<Image>().sprite = engineSprites[GameManager.Instance.GetEngineLvl()];
        }

        timerMsg += Time.deltaTime;
        if (timerMsg > 2f) {
            tuercasMsg.SetActive(false);
            pinturaMsg.SetActive(false);
        }
    }
    
    public void IncreaseEngineLvl() {

        if (GameManager.Instance.GetPlayerTuerca() >= 10) {
            if (GameManager.Instance.GetEngineLvl() < 3) {
                GameManager.Instance.SetEngineLvl(GameManager.Instance.GetEngineLvl() + 1);
                GameManager.Instance.SetPlayerTuerca(GameManager.Instance.GetPlayerTuerca() - 10);
                tuercasMsg.SetActive(true);
                timerMsg = 0;
            }
        }
    }

    public void SetColorBlue() {
        if (GameManager.Instance.GetBikeSpriteID() != 0) {
            if (GameManager.Instance.GetPlayerPintura() >= 5) {
                GameManager.Instance.SetBikeSpriteID(0);
                GameManager.Instance.SetPlayerPintura(GameManager.Instance.GetPlayerPintura() - 5);
                pinturaMsg.SetActive(true);
                timerMsg = 0;
            }
        }
    }
    public void SetColorGreen() {
        if (GameManager.Instance.GetBikeSpriteID() != 1) {
            if (GameManager.Instance.GetPlayerPintura() >= 5) {
                GameManager.Instance.SetBikeSpriteID(1);
                GameManager.Instance.SetPlayerPintura(GameManager.Instance.GetPlayerPintura() - 5);
                pinturaMsg.SetActive(true);
                timerMsg = 0;
            }
        }
        
    }
    public void SetColorRed() {
        if (GameManager.Instance.GetBikeSpriteID() != 2) {
            if (GameManager.Instance.GetPlayerPintura() >= 5) {
                GameManager.Instance.SetBikeSpriteID(2);
                GameManager.Instance.SetPlayerPintura(GameManager.Instance.GetPlayerPintura() - 5);
                pinturaMsg.SetActive(true);
                timerMsg = 0;
            }
        }
    }

    public void ActivateEscape() { GameManager.Instance.SetExhaust(true); }

    public void TutoStepComplete() { if (!GameManager.Instance.tutorialFinished) { mManager.TutoNextStep(); } }
}
