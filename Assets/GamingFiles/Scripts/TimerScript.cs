using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    
    public Transform player;
    private EthanScript myPlayerScript;

    void Start()
    {
        GameStatusScript.timerFlag = false;
        myPlayerScript = player.GetComponent<EthanScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStatusScript.timerFlag)
            return;
        float t = GameStatusScript.startTime - Time.timeSinceLevelLoad; ;
        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString();

        if (int.Parse(minutes) < 10)
            minutes = "0" + minutes;

        if (int.Parse(seconds) < 10)
            seconds = "0" + seconds;

        timerText.text = minutes + ":" + seconds;


        if (minutes == "00" && seconds == "00")
        {
            myPlayerScript.onDeath();
        }
    }
}
