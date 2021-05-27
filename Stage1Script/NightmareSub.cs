using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareSub : MonoBehaviour
{
    public GameObject player;

    public int isHappen;

    public GameObject Door;//문관련
    public GameObject DoorSetting;
    public AudioSource doorSound;
    private Animation anim1;

    public GameObject Chair;//의자관련
    private Transform chairTrans;
    public GameObject Despos;
    private Vector3 movePos;
    public GameObject LightOB;
    public GameObject LightOB2;

    public AudioSource wallCrashSound;//벽소리

    void Start()
    {
        anim1 = Door.GetComponent<Animation>();
        chairTrans = Chair.GetComponent<Transform>();
        movePos = Despos.GetComponent<Transform>().position;
    }

    void OnTriggerEnter()
    {
        if (isHappen == 0)
        {
            wallCrashSound.Play();
        }
        else if (isHappen == 1)
        {
            if (!(DoorSetting.GetComponent<DoorOpenCtrl>().CloseD))
            {
                anim1.Play("CloseTheDoor");
                doorSound.Play();
                DoorSetting.GetComponent<DoorOpenCtrl>().CloseD = true;
            }
        }
        else if (isHappen == 2)
        {
            chairTrans.position = Vector3.MoveTowards(chairTrans.position, movePos, 1.0f * Time.deltaTime);
            Chair.GetComponent<AudioSource>().Play();
        }
        else if (isHappen == 4) {
            LightOB.GetComponent<Light>().intensity = 0.0f;
            LightOB2.GetComponent<Light>().intensity = 0.0f;
        }
            this.GetComponent<BoxCollider>().enabled = false;
    }
}
