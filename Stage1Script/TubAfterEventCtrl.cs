using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TubAfterEventCtrl : MonoBehaviour
{
    public GameObject Player;

    //public GameObject InterIcon;
    public GameObject Aim;
    public GameObject FadeSc;
    public GameObject ObjectInfo;

    public GameObject nextTrig;
    public GameObject LastTubEvent;
    public GameObject checkTimer;

    public AudioSource tubGhost;
    private Text tempText;
    //private Animation tempAnim;

    // Start is called before the first frame update
    void Start()
    {
       // tempAnim = FadeSc.GetComponent<Animation>();
        tempText = ObjectInfo.GetComponent<Text>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        StartCoroutine(CheckCount());
    }


    IEnumerator CheckCount() {

        tempText.text = "잠시 기다렸다가 돌아가자.";

        yield return new WaitForSeconds(3.0f);
        checkTimer.SetActive(true);

        Aim.SetActive(false);
       // tempAnim.Play("FadeScAnim2");//화면 검정 
        Player.GetComponent<FirstPersonController>().enabled = false;
        ///
        yield return new WaitForSeconds(10.0f);
        Aim.SetActive(true);
        checkTimer.SetActive(false);
        // tempAnim.Play("FadeScAnim3");//화면 검정 
        this.GetComponent<BoxCollider>().enabled = false;
        Player.GetComponent<FirstPersonController>().enabled = true;

        yield return new WaitForSeconds(2.0f);
        tempText.text = "날카로운 물건을 챙기고 화장실로 가자.";
        nextTrig.SetActive(true);
        LastTubEvent.SetActive(true);
        tubGhost.Play();
        yield return new WaitForSeconds(2.0f);
        tempText.text = "";
    }
}
