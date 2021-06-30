using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Transform respawnTransform;

    #region Singelton
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameStatusScript.isGameStarted = true;
    }

    #endregion

    public GameObject player;
}
