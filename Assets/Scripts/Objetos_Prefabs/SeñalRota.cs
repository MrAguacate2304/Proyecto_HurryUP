using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeñalRota : MonoBehaviour
{
    Animator animator;
    bool rota;
    float contador;
    bool contadorStart;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rota = false;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rota)
        {
            animator.SetBool("Rota", true);
        }
        if (!rota)
        {
            animator.SetBool("Rota", false);
        }
        if (contadorStart)
        {
            contador += Time.deltaTime;
            if (contador >= 120)
            {
                rota = false;
                contador = 0;
                contadorStart = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { rota = true; }
        if (collision.gameObject.tag == "IA") { rota = true; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        contadorStart = true;
        contador = 0;
    }
}
