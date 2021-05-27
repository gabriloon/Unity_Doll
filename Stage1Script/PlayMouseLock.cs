using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayMouseLock : MonoBehaviour
{
 
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor visible
        Cursor.visible = false;
     

    }
}
