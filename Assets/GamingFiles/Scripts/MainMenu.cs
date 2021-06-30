using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button startButton;
    public Button continueButton;

    private void Start()
    {
        Debug.Log(GameStatusScript.isGameStarted);
        if (GameStatusScript.isGameStarted)
        {
            continueButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
        } else
        {
            continueButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
