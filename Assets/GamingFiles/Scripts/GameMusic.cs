using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public static float gameVolume = 1;


    public AudioSource[] gameMusics;

    // Start is called before the first frame update
    void Start()
    {
        foreach (AudioSource audio in gameMusics)
        {
            audio.volume = gameVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
