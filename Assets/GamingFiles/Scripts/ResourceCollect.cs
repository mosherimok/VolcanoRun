using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollect : MonoBehaviour
{
    public float healthValue;
    public AudioSource collectSound;
    EthanScript myPlayerScript;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collectSound.Play();
            myPlayerScript = collider.GetComponent<EthanScript>();
            myPlayerScript.gainHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
