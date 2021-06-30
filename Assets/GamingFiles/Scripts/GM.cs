using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 24;
    public int score = 0;
    public float endDelay = 1f;
    public Text livesText;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject youWon;
    //public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;

    private GameObject clonePaddle;
   // private GameObject cloneBricks;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        score = GameStatusScript.score;
        GameStatusScript.isGameStarted = false;
        //cloneBricks = Instantiate(bricksPrefab, transform.position, Quaternion.identity) as GameObject;
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("GetBackToGame", endDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("GetBackToGame", endDelay);
        }

    }

    void GetBackToGame()
    {
        Time.timeScale = 1f;
        GameStatusScript.score = score;
        GameStatusScript.breakoutGameNotPlayed = false;
        SceneManager.LoadScene("Game");
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);

        if (lives != 0)
            Invoke("SetupPaddle", endDelay);

        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        score += 10;
        scoreText.text = "Coins: " + score;
        bricks--;
        CheckGameOver();
    }
}