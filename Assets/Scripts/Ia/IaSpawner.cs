using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaSpawner : MonoBehaviour
{
    public GameObject IaCarsPrefab;

    void Update()
    {
        if (GameManager.Instance.night)
        {
            IaCarsPrefab.SetActive(false);
        }
        else
        {
            IaCarsPrefab.SetActive(true);
        }
    }
}
