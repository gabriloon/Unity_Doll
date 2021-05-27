using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Effect : MonoBehaviour
{
    public AudioSource aud1;
    public GameObject initLamp;
    public GameObject showLamp;
    public GameObject initMirror;
    public GameObject showMirror;

    public GameObject NextTrigger;
    // Start is called before the first frame update

    void OnTriggerEnter()
    {
        StartCoroutine(eventRoom());
        this.GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator eventRoom() {

        yield return new WaitForSeconds(1.0f);
        aud1.Play();
        initLamp.SetActive(false);
        showLamp.SetActive(true);
        initMirror.SetActive(false);
        showMirror.SetActive(true);
        NextTrigger.SetActive(true);
    }
}
