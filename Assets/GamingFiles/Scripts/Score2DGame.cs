using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2DGame : MonoBehaviour
{
    public Text scoreText;
    public int coinValue;

    private int score;

    void Start()
    {
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameStatusScript.score += 50;
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            score -= 100;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "SCORE:\n" + GameStatusScript.score;
    }
}
