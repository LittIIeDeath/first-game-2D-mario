using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scpPlayer : MonoBehaviour
{
  
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    bool isBlowing;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // move o personagem em uma direçao
        // transform.position += movement * Time.deltaTime * Speed;

        float movement = Input.GetAxis("Horizontal");
        
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        
        // direita
        if(movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        // esquerda
        if(movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        // parado
        if(movement == 0f)
        {
            anim.SetBool("walk", false);
        }
        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing)
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    // Metodo para saber se o personagem esta no chao
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            isBlowing = false;
        } 

        if(collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Saw")
        {
            Destroy(gameObject);
            scpGameController.instance.ShowGameOver();
        }  
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }   
    }

    void OnTriggerStray2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }
}
