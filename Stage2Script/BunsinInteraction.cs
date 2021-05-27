using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BunsinInteraction : MonoBehaviour
{
    private float Distance;
    //public GameObject player;
    public GameObject holdIcon;
    public GameObject whiteIcon;
    public GameObject Aim;
    public GameObject playerSpe;


    public GameObject ShowOb;//책상위에 랜턴 


    public GameObject StandPlayer;

    public GameObject sitPlayer;



    public bool sit;



    //이걸 겹치는 걸 없애고 간단히 할수 있는데.
    private void OnMouseOver()
    {
        Distance = PlayRay.DistanceFromTarget;


        if (Distance <= 1.5f)
        {
            if (!sit)
            {
                holdIcon.SetActive(true);
                Aim.SetActive(false);
            }
            else {
                whiteIcon.SetActive(true);
                Aim.SetActive(false);

            }
            if (Input.GetButtonDown("Interaction"))//E키
            {
                StartCoroutine(SitDownChair());
            }
        }
        else
        {
            holdIcon.SetActive(false);
            whiteIcon.SetActive(false);
            Aim.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        holdIcon.SetActive(false);
        whiteIcon.SetActive(false);
        Aim.SetActive(true);
    }

    IEnumerator SitDownChair()//의자 앉거나 일어나거나
    {
        if (sit)//다시 일어나게 하기 위해서
        {
            sitPlayer.SetActive(false);
            StandPlayer.SetActive(true);
            
            ShowOb.SetActive(false);
            
            sit = !sit;
        }
        else//앉게 한다.
        {
            sitPlayer.SetActive(true);
            StandPlayer.SetActive(false);

            ShowOb.SetActive(true);
            sit = !sit;

        }
        yield return null;

    }
}

