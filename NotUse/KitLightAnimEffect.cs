using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitLightAnimEffect : MonoBehaviour
{
    public GameObject kitLight1;
    public GameObject kitLight2;
    //public GameObject kitLightEtc;
    public GameObject kitLightOffTrig;

    public GameObject LightClickerSound;
    public GameObject LightClickerSound2;

    private Animation kitLightAnim1;
    private Animation kitLightAnim2;
    private Animation kitLightEtcAnim;
    private AudioSource LightSound;
    private AudioSource LightSound2;


    void Start()
    {
        //kitLightEtc.SetActive(true);
       // kitLightEtcAnim = kitLightEtc.GetComponent<Animation>();
        kitLightAnim1 = kitLight1.GetComponent<Animation>();
        kitLightAnim2 = kitLight2.GetComponent<Animation>();
        LightSound = LightClickerSound.GetComponent<AudioSource>();
        LightSound2 = LightClickerSound2.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        kitLightAnim1.Play("KitLightAnim");
        kitLightAnim2.Play("KitLightAnim");
        //kitLightEtcAnim.Play("KitLightAnim");

        LightSound.Play();
        LightSound2.Play();
        kitLightOffTrig.SetActive(true);
    }
}
