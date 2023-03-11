using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scpApple : MonoBehaviour
{



private SpriteRenderer sr;
private CircleCollider2D circle;

public GameObject collected;
public int score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            scpGameController.instance.totalScore += score;

            scpGameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.7f);
        }
    }
}
