using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour {
    
    public AudioSource collectSound;
    EthanScript myPlayerScript;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collectSound.Play();
            Debug.Log(collider.gameObject.tag);
            myPlayerScript = collider.gameObject.GetComponent<EthanScript>();
            myPlayerScript.gainCoin(50);
            GameStatusScript.coinsToActivate[gameObject.name] = false;
            Destroy(gameObject);
        }
        
    }
}
