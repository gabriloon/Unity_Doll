using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightCtrl : MonoBehaviour
{
    public bool flashLightEnabled;
    public GameObject flashLight;
    public AudioSource clickButton;

    private bool havePh;
    //public GameObject lightObj;

    private void Start()
    {
        havePh = KeyCheck.phoneKey;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && havePh)
        {
           // Debug.Log("CLick");
            flashLightEnabled = !flashLightEnabled;
            clickButton.Play();
        }

        if (flashLightEnabled)
        {
            flashLight.SetActive(true);
        }
        else {
            flashLight.SetActive(false);
        }


        }
    }
