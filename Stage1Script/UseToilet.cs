using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UseToilet : MonoBehaviour
{
    public GameObject interactionIcon;
    public GameObject Aim;
    public GameObject ObjectInfo;

    public GameObject player;
    public GameObject FadeSc;
    public GameObject ToiletObCube4;

    private Animation tempAnim;
    private float tempDistance;
    private AudioSource tempAud;
    private bool usedToilet;
    private Text tempText;

    // Start is called before the first frame update
    void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
        tempAud = this.GetComponent<AudioSource>();
        tempText = ObjectInfo.GetComponent<Text>();
        usedToilet = true;

    }


     void OnMouseOver()
    {
        tempDistance = Vector3.Distance(player.transform.position, this.transform.position);

        if (tempDistance <= 2.5f) {
            interactionIcon.SetActive(true);
            Aim.SetActive(false);

            if (Input.GetButtonDown("Interaction")) {
                StartCoroutine(usingToilet());
            }
        }
        else
        {
            interactionIcon.SetActive(false);
            Aim.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        interactionIcon.SetActive(false);
        Aim.SetActive(true);
    }


    IEnumerator usingToilet() {

        if (usedToilet)//변기를 사용했는가?
        {
            tempAnim.Play("FadeScAnim2");//화면 검정 
            yield return new WaitForSeconds(2.0f);
            tempAud.Play();
            player.GetComponent<FirstPersonController>().enabled = false;
            yield return new WaitForSeconds(1.0f);
            ToiletObCube4.GetComponent<Animation>().Play("ToiletHeadClose");
            yield return new WaitForSeconds(1.0f);
            tempAnim.Play("FadeScAnim4");
            player.GetComponent<FirstPersonController>().enabled = true;
            usedToilet = false;
        }
        else
        {
            tempText.text = "사용할 기분이 아니다.";
            yield return new WaitForSeconds(2.0f);
            tempText.text = "";
        }
        }
}
