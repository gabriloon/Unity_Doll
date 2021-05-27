using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Screen.SetResolution(1920,1080, true);
        //Screen.SetResolution(Screen.width, (Screen.width / 2) * 3, true);
    }
}
