using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraFollow : MonoBehaviour
{

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = playerPos;
    }
}
