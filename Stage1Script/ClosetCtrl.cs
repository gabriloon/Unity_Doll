using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetCtrl : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    private bool CloseD = true;
    private Animation tempAnim;
    private AudioSource tempAudio;
    void Start()
    {
        tempAnim = this.GetComponent<Animation>();
        tempAudio = this.GetComponent<AudioSource>();
    }
    void OnMouseOver()
    { 
        TheDistance = PlayRay.DistanceFromTarget;

        if (TheDistance <= 5.0f && CloseD)
        {
            ActionDisplay.SetActive(true);
        }
        else if ((TheDistance <= 5.0f) && !CloseD)
        {
            ActionDisplay.SetActive(true);
        }


        if (Input.GetButtonDown("Interaction"))
        {
            if (TheDistance <= 5.0f && CloseD)
            {
                ActionDisplay.SetActive(true);
                    tempAnim.Play("ClosetAnim");
                    tempAudio.Play();
                CloseD = false;

            }
            else if ((TheDistance <= 5.0f) && !CloseD)
            {
                ActionDisplay.SetActive(true);
                    tempAnim.Play("ClosetAnimClose");//닫히는 애니메이션
                    tempAudio.Play();
                CloseD = true;

            }
        }
    }


    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
    }
}