using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2Dd : MonoBehaviour
{
    public Text scoreText;
    public int coinValue;

    private int score;

    void Start()
    {
        UpdateScore(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bomb")
        {
            UpdateScore(-100);
        }
        if (other.tag == "Coin")
        {
            UpdateScore(50);
        }
        Destroy(other);
    }

    void UpdateScore(int score)
    {
        GameStatusScript.score += score;
        scoreText.text = "SCORE:\n" + GameStatusScript.score;
    }
}
