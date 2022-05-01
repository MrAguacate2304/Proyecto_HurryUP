using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightController : MonoBehaviour
{
    public GameObject filter;

    void Update()
    {
        if (GameManager.Instance.night)
        {
            filter.SetActive(true);
        }
        else
        {
            filter.SetActive(false);
        }
    }
}
