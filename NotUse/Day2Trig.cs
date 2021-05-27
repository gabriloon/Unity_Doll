using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Day2Trig : MonoBehaviour
{
    public GameObject blackMan;
    public PostProcessProfile postProfile;

    private AudioSource tempSource;

    private void Start()
    {
     
        tempSource = blackMan.GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(day2Event());


    }


    IEnumerator day2Event() {
        yield return new WaitForSeconds(1.0f);
        blackMan.SetActive(true);
        tempSource.Play();
        postProfile.GetSetting<Grain>().intensity.value = 1.0f;
        yield return new WaitForSeconds(1.0f);
        tempSource.Stop();
        postProfile.GetSetting<Grain>().intensity.value = 0.0f;
        blackMan.SetActive(false);
    }
}
