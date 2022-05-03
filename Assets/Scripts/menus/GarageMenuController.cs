using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageMenuController : MonoBehaviour
{
    public void SetEngineLvl1() { GameManager.Instance.SetEngineLvl(1); }
    public void SetEngineLvl2() { GameManager.Instance.SetEngineLvl(2); }
    public void SetEngineLvl3() { GameManager.Instance.SetEngineLvl(3); }

    public void SetColorBlue() { GameManager.Instance.SetBikeSpriteID(0); }
    public void SetColorGreen() { GameManager.Instance.SetBikeSpriteID(1); }
    public void SetColorRed() { GameManager.Instance.SetBikeSpriteID(2); }

    public void ActivateEscape() { GameManager.Instance.SetExhaust(true); }

}
