using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneGet : MonoBehaviour
{
    private float Distance;
    public GameObject holdIcon;
    public GameObject Aim;
    public GameObject playerSpe;
    public GameObject ShowOb;
    public GameObject DisshowOb;

    //public bool firstPhone=true;

    //이걸 겹치는 걸 없애고 간단히 할수 있는데.
    private void OnMouseOver()
    {
        Distance = PlayRay.DistanceFromTarget;


        if  (Distance <= 2.0f)
        {
            holdIcon.SetActive(true);
            Aim.SetActive(false);
            if (Input.GetButtonDown("Interaction"))
            {
                StartCoroutine(phoneHaving());
            }
        }
        else
        {
            holdIcon.SetActive(false);
            Aim.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        holdIcon.SetActive(false);
        Aim.SetActive(true);
    }

    IEnumerator phoneHaving()//플레이어가 휴대폰 얻었을시에
    {
       holdIcon.SetActive(false);
        Aim.SetActive(true);
        ShowOb.SetActive(true);
        DisshowOb.SetActive(false);//
        KeyCheck.phoneKey = true;
        this.GetComponent<BoxCollider>().enabled = false;
        playerSpe.GetComponent<Text>().text = "F키를 눌러 불을 킬 수 있습니다.";
        yield return new WaitForSeconds(2.0f);
            playerSpe.GetComponent<Text>().text = "";
  
    }
    }