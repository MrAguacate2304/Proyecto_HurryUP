using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoinsXP : MonoBehaviour
{

    public TMP_Text money;
    public TMP_Text xp;

    void Update()
    {
        money.text = "DINERO: " + GameManager.Instance.GetPlayerCoins() + "$";
        xp.text = "EXPERIENCIA: " + GameManager.Instance.GetPlayerXP() + "XP";
    }
}
