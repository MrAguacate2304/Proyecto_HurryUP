using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameManager.Instance.introduction = true;
                Destroy(this.gameObject);
            }
        }
    }
}
