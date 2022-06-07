using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaSpawner : MonoBehaviour
{
    public GameObject IaCarsPrefab;
    public GameObject IaEnemyPrefab;
    GameObject currentEnemies;

    bool enemySpawned;

    private void Start()
    {
        enemySpawned = false;
    }

    void Update()
    {
        if (GameManager.Instance.night)
        {
            IaCarsPrefab.SetActive(false);
            if (!enemySpawned) {
                currentEnemies = Instantiate(IaEnemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                enemySpawned = true;
            }
        }
        else {
            IaCarsPrefab.SetActive(true);
            if (enemySpawned) {
                Destroy(currentEnemies);
                enemySpawned = false;
            }
        }
    }
}
