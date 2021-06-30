using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardListener : MonoBehaviour
{
    public Avatar ethanAvatar; // A reference to the ThirdPersonCharacter on the object
    public Avatar goblinAvatar; // A reference to the ThirdPersonCharacter on the object
    public Transform player; // A reference to the ThirdPersonCharacter on the object

    private bool isEthanEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        player.Find("Goblin").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStatusScript.checkPoint = player.transform.position;
            GameStatusScript.timerFlag = false;
            GameStatusScript.startTime = GameStatusScript.startTime - Time.timeSinceLevelLoad; 
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isEthanEnabled)
            {
                player.Find("EthanBody").gameObject.SetActive(false);
                player.Find("EthanGlasses").gameObject.SetActive(false);
                player.Find("EthanSkeleton").gameObject.SetActive(false);
                player.Find("Goblin").gameObject.SetActive(true);
                player.GetComponent<Animator>().avatar = goblinAvatar;
            }
            else
            {

                player.Find("EthanBody").gameObject.SetActive(true);
                player.Find("EthanGlasses").gameObject.SetActive(true);
                player.Find("EthanSkeleton").gameObject.SetActive(true);
                player.Find("Goblin").gameObject.SetActive(false);
                player.GetComponent<Animator>().avatar = ethanAvatar;

            }
            isEthanEnabled = !isEthanEnabled;
            
        }
    }
}
