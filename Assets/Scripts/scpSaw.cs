using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scpSaw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight = true;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        if(dirRight)
        {
            // verdadeiro direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // falso esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if(timer >= moveTime)
        {
            // altera de + pra - ou - pra + e reseta o valor
            dirRight = !dirRight;
            timer = 0f;
        }

    }
}
