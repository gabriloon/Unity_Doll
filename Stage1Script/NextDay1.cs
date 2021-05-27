using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class NextDay1 : MonoBehaviour
{
    private float Distance;
 
    public GameObject Player;
    public GameObject InterIcon;
    public GameObject Aim;
    public GameObject FadeSc;

    public GameObject Clock1;
    public GameObject Clock2;

    public GameObject phone;
    public GameObject tub;


    private Animation tempAnim;
    public AudioSource bedSound;
   // public AudioSource NightSound;

    private void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
    }
    IEnumerator dollHaving()
    {
        //setDoll.SetActive(true);

                bedSound.Play();
                tempAnim.Play("FadeScAnim2");//화면 검정 
                Player.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(4.0f);

        /*
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
            setNum = Random.Range(0, wayPoints.Count);
        }

        doll.GetComponent<Transform>().position=wayPoints[setNum].position;
        //인형 위치 배치.

        if (Lightergroup != null)
        {
            Lightergroup.GetComponentsInChildren<Transform>(wayPoints2);
            wayPoints2.RemoveAt(0);
            setNum2 = Random.Range(0, wayPoints2.Count);
        }
        Lighter.GetComponent<Transform>().position = wayPoints2[setNum2].position;

        yield return new WaitForSeconds(2.0f);
        */


        bedSound.Stop();
 this.GetComponent<BoxCollider>().enabled = false;


        InterIcon.SetActive(false);
                Aim.SetActive(true);
        tub.SetActive(true);
        Clock1.SetActive(false);
        Clock2.SetActive(true);
        phone.SetActive(true);

        yield return new WaitForSeconds(1.0f);
                tempAnim.Play("FadeScAnim3");
                Player.GetComponent<FirstPersonController>().enabled = true;
               // NightSound.Play();  //>


        yield return new WaitForSeconds(2.0f);
        
    }

    void OnMouseOver()
    {
        Distance = PlayRay.DistanceFromTarget;
        Debug.Log("침대" + Distance);

        if (Distance <= 4)
        {
            Aim.SetActive(false);
            InterIcon.SetActive(true);
        }
        if (Input.GetButtonDown("Interaction"))
        {
            if (Distance <= 4)
            {
                StartCoroutine(dollHaving());
            }
        }
    }
    void OnMouseExit()
    {
        Aim.SetActive(true);
        //ActionDisplay.SetActive(false);
        InterIcon.SetActive(false);
    }


}
