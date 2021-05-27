using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightSwitchCtrl : MonoBehaviour
{
    public float TheDistance;
    //public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject LightOb;
   // public GameObject LightOb2;
    public bool isLight = true;
    public float lightInt = 3.0f;
    public AudioSource bc;
    private Light tempLight;
   // private Light tempLight2;
    void Start()
    {
        tempLight = LightOb.GetComponent<Light>();
        //tempLight2 = LightOb2.GetComponent<Light>();
    }

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
                    //LightOb2.SetActive(false);
                    //tempLight2.intensity = 0f;
                    bc.Play();
                    isLight = false;
                    //버튼 사운드 플레이(딸깍)
                }
                else if (TheDistance <= 2 && !isLight)
                {
                    tempLight.intensity = lightInt;
                  //  LightOb2.SetActive(true);
                    //tempLight2.intensity = 3f;
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