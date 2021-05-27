using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class FryingPanInteraction : MonoBehaviour
{
    private float Distance;
    public static bool eatFood;
    public GameObject Player;

    public GameObject ObjectInfo;
      public GameObject IactionIcon;
    public GameObject Aim;
    public GameObject FadeSc;

    public GameObject panUi;
    public GameObject ateShowOb;

    private Animation tempAnim;
    private Text tempText;
    public AudioSource CookSound;
    public AudioSource CookSound2;


    private void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
        tempText = ObjectInfo.GetComponent<Text>();
    }

    IEnumerator dollHaving()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            if (Distance <= 2.0f)
            {
                tempAnim.Play("FadeScAnim2");//화면 검정 
                eatFood = true;//다시 유저가 밥먹고 돌아갈때 Trigger를 활성화시키기 위한 조건.
               
                yield return new WaitForSeconds(2.0f);
                Player.GetComponent<FirstPersonController>().enabled = false;
                CookSound.Play();//요리소리 
                CookSound2.Play();
                panUi.SetActive(false);//기존 프라이팬  
                ateShowOb.SetActive(true);//밥먹고 싱크대에 있는 오브젝트 활성화   
                yield return new WaitForSeconds(7.0f);
                CookSound.Stop();//요리소리 
                CookSound2.Stop();
                this.GetComponent<BoxCollider>().enabled = false;
                tempAnim.Play("FadeScAnim3");
                Aim.SetActive(true);
                yield return new WaitForSeconds(2.0f);
                Player.GetComponent<FirstPersonController>().enabled = true;
                tempText.text = "속이 든든해진거 같다.";
                yield return new WaitForSeconds(2.0f);
                tempText.text ="";
           
            }
            yield return new WaitForSeconds(2.0f);
        }
    }

    void OnMouseOver()
    {
        Distance = PlayRay.DistanceFromTarget;
        if (Distance <= 2)
        {
            Aim.SetActive(false);
            IactionIcon.SetActive(true);
        }
        if (Input.GetButtonDown("Interaction"))
        {
            if (Distance <= 2 && !eatFood)
            {
                StartCoroutine(dollHaving());
            }
        }
    }
    void OnMouseExit()
    {
        IactionIcon.SetActive(false);
        Aim.SetActive(true);
    }


}
