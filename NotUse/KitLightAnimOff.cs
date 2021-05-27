using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitLightOff : MonoBehaviour
{
    public GameObject kitLight1;
    public GameObject kitLight2;
    //public GameObject kitLightEtc;

    public GameObject LightClickerSound;
    public GameObject LightClickerSound2;

    public GameObject nextTrig;
     //public AudioSource BreathSound;

    private Animation kitLightAnim1;
    private Animation kitLightAnim2;
  
    private AudioSource LightSound;
    private AudioSource LightSound2;

    // Start is called before the first frame update
    void Start()
    {
        //kitLightEtcAnim = kitLightEtc.GetComponent<Animation>();
        kitLightAnim1 = kitLight1.GetComponent<Animation>();
        kitLightAnim2 = kitLight2.GetComponent<Animation>();
        LightSound = LightClickerSound.GetComponent<AudioSource>();
        LightSound2 = LightClickerSound2.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        kitLightAnim1.Stop("KitLightAnim");
        kitLightAnim2.Stop("KitLightAnim");
       

       // BreathSound.Play();
        kitLight1.GetComponent<Light>().intensity = 0.0f;
        kitLight2.GetComponent<Light>().intensity = 0.0f;
        //kitLightEtc.GetComponent<Light>().intensity = 0.0f;

        LightSound.Stop();
        LightSound2.Stop();
    }
}
