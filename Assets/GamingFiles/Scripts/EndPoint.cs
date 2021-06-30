using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{
    public MidMenuScript victoryMenu;

    public float messageFadeOutSpeed = 0.2f;

    public Text NotEnoughCoinsText;

    private void Start()
    {
        NotEnoughCoinsText.color = Color.clear;
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            if (GameStatusScript.score < 1000)
            {
                NotEnoughCoinsText.color = Color.white;
                StartCoroutine(FadeTextToZeroAlpha(messageFadeOutSpeed, NotEnoughCoinsText));
            }
            else
            {
                EthanScript myPlayerScript = collider.GetComponent<EthanScript>();
                victoryMenu.ToggleEndMenu(GameStatusScript.score);
                GameStatusScript.InitializeStats();
                Destroy(collider.gameObject);
            }
        }
    }
}
