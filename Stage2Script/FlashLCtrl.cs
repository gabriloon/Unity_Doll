
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLCtrl : MonoBehaviour
{
    //Not Using
    //Not Using
    //Not Using



    public bool flashLightEnabled;
    public GameObject flashLight;
    public AudioSource clickButton;

    public bool haveNotFlash;
    //public GameObject lightObj;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !haveNotFlash)
        {
            // Debug.Log("CLick");
            flashLightEnabled = !flashLightEnabled;
            clickButton.Play();
        }

        if (flashLightEnabled)
        {
            flashLight.SetActive(true);
        }
        else
        {
            flashLight.SetActive(false);
        }


    }
}

