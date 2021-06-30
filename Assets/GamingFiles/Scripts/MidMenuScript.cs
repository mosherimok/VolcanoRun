using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MidMenuScript : MonoBehaviour
{
    public Text lives;
    public Text scoreText;
    public Text timer;
    public Image healthBar;
    public Text endScore;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);

        Debug.Log(((int)score).ToString());
        endScore.text = ((int)score).ToString();

        lives.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Restarted");
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
