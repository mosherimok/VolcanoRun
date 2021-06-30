using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(GameStatusScript.breakoutGameNotPlayed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameStatusScript.timerFlag = true;
            GameStatusScript.startTime = GameStatusScript.startTime - Time.timeSinceLevelLoad;
            GameStatusScript.checkPoint = collider.transform.position;
            SceneManager.LoadScene("BreakoutGame");
        }
    }
}
