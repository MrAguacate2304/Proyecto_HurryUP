using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{
    public GameObject mManagerObj;
    MisionManager misionManager;

    void Start()
    {
        misionManager = mManagerObj.GetComponent<MisionManager>();
        misionManager.StartTutorial();
        Destroy(this.gameObject);
    }
}
