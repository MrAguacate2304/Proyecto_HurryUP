using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateWallet : MonoBehaviour
{
    public TMP_Text tuercas;
    public TMP_Text pintura;

    void Update()
    {
        tuercas.text = "" + GameManager.Instance.GetPlayerTuerca();
        pintura.text = "" + GameManager.Instance.GetPlayerPintura();
    }
}
