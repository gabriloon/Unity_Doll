using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    public GameObject theLight;
   //public GameObject LightEtc;
    private Animation tempAnim;

    private void Start()
    {
        tempAnim = theLight.GetComponent<Animation>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("FrontHall Light Trigg");
        tempAnim.Play("LightOn");
       // LightEtc.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        tempAnim.Play("LightOff");
       // LightEtc.SetActive(false);
    }

}