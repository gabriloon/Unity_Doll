using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch2 : MonoBehaviour
{
    public float TheDistance;
    //public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject LightOb;
    public GameObject lightEtc;
    //public GameObject LightOb2;
    public bool isLight = true;
    public AudioSource bc;
    public float LightInt = 5.73f;
    private Light tempLight;
    void Start()
    {
        tempLight = LightOb.GetComponent<Light>();
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        TheDistance = PlayRay.DistanceFromTarget;

        if (TheDistance <= 2)
        {
            //ExtraCross.SetActive(true);
            //ActionText.GetComponent<Text>().text = "Press a light Switch";
            // ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Interaction"))
        {
            if (!KeyCheck.isNightmare)
            {

                if (TheDistance <= 2 && isLight)
                {
                    tempLight.intensity = 0f;
                    lightEtc.SetActive(false);
                    //LightOb2.GetComponent<Light>().intensity = 0f;
                    bc.Play();
                    isLight = false;
                    //버튼 사운드 플레이(딸깍)
                }
                else if (TheDistance <= 2 && !isLight)
                {
                    tempLight.intensity = LightInt;
                    //LightOb2.GetComponent<Light>().intensity = 3.2f;
                    lightEtc.SetActive(true);
                    bc.Play();
                    isLight = true;
                }
            }
            else {
                bc.Play();
            }
        }
    }
    void OnMouseExit()
    {
        //ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }


}