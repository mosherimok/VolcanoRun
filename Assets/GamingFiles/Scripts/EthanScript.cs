using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EthanScript : MonoBehaviour {

    public float health = 1;
    public GameObject scoreText;
    public MidMenuScript deathMenu;
    public MidMenuScript victoryMenu;
    private GameObject[] coins;
    public AudioSource painSound;
    public AudioSource falloutSound;

    [Header("Unity stuff")]
    public Image healthBar;
    public bool isDead = false;
    

    
    public Transform fallout;
    public Transform beforeFallout;

    public GameObject livesText;

    // Use this for initialization
    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        
        gainCoin(0);
        setPosition(GameStatusScript.checkPoint);
        livesText.GetComponent<Text>().text = "Lives: " + GameStatusScript.lives;

        if (GameStatusScript.initiateCoins)
        {
            foreach (GameObject coin in coins)
            {
                if (!GameStatusScript.coinsToActivate.ContainsKey(coin.name))
                {
                    GameStatusScript.coinsToActivate.Add(coin.name, true);
                }
                else
                {
                    GameStatusScript.coinsToActivate[coin.name] = true;
                }
            }

            GameStatusScript.initiateCoins = false;
        }
        else
        {
            foreach (GameObject coin in coins)
            {
                GameObject.Find(coin.name).SetActive(GameStatusScript.coinsToActivate[coin.name]);
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (isDead)
            Destroy(gameObject);
		
	}

    public void setPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void gainHealth(float healthValue)
    {
        health += healthValue;

        if (health > 1)
            health = 1;

        healthBar.fillAmount = health;
    }

    public void loseHealth(float healthValue)
    {
        painSound.Play();
        health -= healthValue;
        healthBar.fillAmount = health;

        if (health <= 0)
        {
            transform.position = GameStatusScript.checkPoint;
            health = 1;
            healthBar.fillAmount = health;
            updateLife();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="ball")
        {
            loseHealth(0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == beforeFallout)
        {
            Debug.Log("before");
            falloutSound.Play();
        }

        if (other.transform == fallout)
        {
            Debug.Log("after");
            transform.position = GameStatusScript.checkPoint;
            updateLife();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform == fallout)
    //    {
    //        Debug.Log("Exit");
    //        transform.position = GameStatusScript.checkPoint;
    //        falled = 0;
    //        updateLife();
    //    }
    //}

    private void updateLife()
    {
        GameStatusScript.lives -= 1;
        health = 1;
        healthBar.fillAmount = health;

        livesText.GetComponent<Text>().text = "Lives: " + GameStatusScript.lives;

        if (GameStatusScript.lives == 0)
        {
            onDeath();
        }
    }

    public void onDeath()
    {
        isDead = true;
        GameStatusScript.isGameStarted = false;

        deathMenu.ToggleEndMenu(GameStatusScript.score);
        GameStatusScript.InitializeStats();
    }

    public void gainCoin(int value)
    {
        GameStatusScript.score += value;
        scoreText.GetComponent<Text>().text = "Score: " + GameStatusScript.score;
    }

    
}
