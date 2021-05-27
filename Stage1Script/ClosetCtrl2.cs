using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetCtrl2 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject HideDoor;
    private bool CloseD = true;
    private Animation tempAnim;
    private AudioSource tempAudio;
    // Start is called before the first frame update
    void Start()
    {
        tempAnim = HideDoor.GetComponent<Animation>();
        tempAudio = HideDoor.GetComponent<AudioSource>();
    }
    void OnMouseOver()
    {//마우스 올라갔을때
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
                tempAnim.Play("ClosetHAnim");

                tempAudio.Play();
                CloseD = false;

            }
            else if ((TheDistance <= 5.0f) && !CloseD)
            {
                ActionDisplay.SetActive(true);
                tempAnim.Play("ClosetHAnimClose");//닫히는 애니메이션

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