using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision_Manager : MonoBehaviour
{
    public GameObject endPrefab;

    Vector2[] endPosition;
    int maxVectors;
    // Start is called before the first frame update
    void Start()
    {
        //startRandPos(gameObject);
        maxVectors = 3;

        endPosition = new Vector2[maxVectors];

        endPosition[0] = new Vector2(2f, 4f);
        endPosition[1] = new Vector2(6f, 9f);
        endPosition[2] = new Vector2(7f, 7f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randPos()
    {
        int numrandom = 0;
        numrandom = Random.Range(0, maxVectors);
        Debug.Log(numrandom);
        Instantiate(endPrefab, endPosition[numrandom], Quaternion.identity);
    }

    public void startRandPos()
    {
        randPos();
    }
}
