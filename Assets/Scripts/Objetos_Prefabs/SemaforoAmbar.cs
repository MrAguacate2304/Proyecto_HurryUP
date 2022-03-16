using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoAmbar : MonoBehaviour
{
    float contador;
    Animator animator;
    bool on;
    bool contadorStart;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        on = false;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        contadorStart = true;
        

        if (contadorStart)
        {
            contador += Time.deltaTime;
            if (contador >= 1.5f)
            {
                on = false;
                contador = 0;
                contadorStart = false;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (on)
        {
            animator.SetBool("On", true);
        }
        if (!on)
        {
            animator.SetBool("On", false);
        }
    }

}
