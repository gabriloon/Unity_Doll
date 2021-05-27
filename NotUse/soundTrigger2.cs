using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soundTrigger2 : MonoBehaviour
{
    //public AudioSource aud1;
    public GameObject spech;

    void OnTriggerEnter()
    {
      
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(SpeechContent1());

    }

    IEnumerator SpeechContent1()
    {
        spech.GetComponent<Text>().text = "- 저건 뭐지?";
        yield return new WaitForSeconds(2.0f);
        spech.GetComponent<Text>().text = "";
    }

}
