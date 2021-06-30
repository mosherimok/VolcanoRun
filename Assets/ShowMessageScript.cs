using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMessageScript : MonoBehaviour
{
    public Text welcomeText;
    public float fadeSpeed;
    public bool enterance;

    // Start is called before the first frame update
    void Start()
    {
        welcomeText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            enterance = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            enterance = false;
        }
    }

    void ColorChange()
    {
        if (enterance)
        {
            welcomeText.color = Color.Lerp(welcomeText.color, Color.white, fadeSpeed * Time.deltaTime);
        }
        else
        {
            welcomeText.color = Color.Lerp(welcomeText.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }
}
