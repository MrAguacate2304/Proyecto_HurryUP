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

    public TMP_Text bikeLvl;

    public GameObject exhaustSprite;

    private void Update()
    {
        bikeSprite.GetComponent<Image>().sprite = bikeSprites[GameManager.Instance.GetBikeSpriteID()];

        bikeLvl.text = "LEVEL " + GameManager.Instance.GetEngineLvl();

        if (GameManager.Instance.GetExhaust()) { exhaustSprite.SetActive(true); }
        else { exhaustSprite.SetActive(false); }
    }
    
    public void SetEngineLvl1() { GameManager.Instance.SetEngineLvl(1); }
    public void SetEngineLvl2() { GameManager.Instance.SetEngineLvl(2); }
    public void SetEngineLvl3() { GameManager.Instance.SetEngineLvl(3); }

    public void SetColorBlue() { GameManager.Instance.SetBikeSpriteID(0); }
    public void SetColorGreen() { GameManager.Instance.SetBikeSpriteID(1); }
    public void SetColorRed() { GameManager.Instance.SetBikeSpriteID(2); }

    public void ActivateEscape() { GameManager.Instance.SetExhaust(true); }

    public void TutoStepComplete() { if (!GameManager.Instance.tutorialFinished) { mManager.TutoNextStep(); } }
}
