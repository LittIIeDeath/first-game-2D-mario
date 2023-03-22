using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scpBox : MonoBehaviour
{

    public int health = 3;

    public Animator anim;
    public GameObject effectDestroy;

    void Update()
    {
        if(health <= 0)
        {
            // destroi a caixa
            Instantiate(effectDestroy, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("hit");
        health--;
        
    }
}
