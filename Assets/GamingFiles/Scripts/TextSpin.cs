using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5, 0, Space.World);
    }
}
