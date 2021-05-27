using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbyDoorEventStep2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Door;
    public GameObject DoorSetting;
  
    public GameObject lightOb;
    public GameObject lightOb2;
    //public GameObject lightOb3;
    //public GameObject lightOb4;
    public GameObject ShadowEn;
    public GameObject playerSpe;
    public GameObject NextDayOb;

    public AudioSource doorSound;
    public AudioSource playerScareSound;
    public AudioSource ghostSound;

    private Text TempText;
    private Animation anim1;
    private Animation tempLightAnim;
    private Animation tempLightAnim2;
    //private Animation tempLightAnim3;
    //private Animation tempLightAnim4;
    private Animation tempShadowAnim;

    private AudioSource tempLightAud;
    private AudioSource tempShadowAud;
    private AudioSource tempShadowAud2;
    private Vector3 currentPos;

    void Start()
    {
        anim1 = Door.GetComponent<Animation>();
        tempLightAnim = lightOb.GetComponent<Animation>();
        tempLightAnim2 = lightOb2.GetComponent<Animation>();
        //tempLightAnim3 = lightOb3.GetComponent<Animation>();
        //tempLightAnim4 = lightOb4.GetComponent<Animation>();

        tempLightAud = lightOb2.GetComponent<AudioSource>();

        tempShadowAnim = ShadowEn.GetComponent<Animation>();
        tempShadowAud = ShadowEn.GetComponent<AudioSource>();
        tempShadowAud2 = ghostSound.GetComponent<AudioSource>();

        TempText = playerSpe.GetComponent<Text>();
        currentPos = ShadowEn.transform.position;

    }

    void OnTriggerEnter()
    {
        StartCoroutine(dayRoom());
        //이 방에 불 다꺼지고 
        //괴 형체가 나타나 가까이 다가온다.
        //distance 일정거리 가까워지면 사라진다. 
        //  DoorSetting.GetComponent<DoorOpenCtrl>().isLock = false;
    }


    IEnumerator dayRoom() {

        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1.0f);
       anim1.Play("CloseTheDoor");
        doorSound.Play();
        DoorSetting.GetComponent<DoorOpenCtrl>().CloseD = true;
        DoorSetting.GetComponent<DoorOpenCtrl>().isLock = true;
        yield return new WaitForSeconds(2.0f);
        tempLightAnim.Play("LightOffLoop");
        tempLightAnim2.Play("LightOffLoop");
        //tempLightAnim3.Play("LightOffLoop");
        //tempLightAnim4.Play("LightOffLoop");
        tempLightAud.Play();
        yield return new WaitForSeconds(7.0f);


        //tempLightAnim3.Stop();
       // lightOb3.SetActive(false);//후처리
        //yield return new WaitForSeconds(6.0f);

        tempLightAnim.Stop();
        lightOb.SetActive(false);//후처리
        yield return new WaitForSeconds(6.0f);

        //tempLightAnim4.Stop();
        //lightOb4.SetActive(false);//후처리
        //yield return new WaitForSeconds(4.0f);

        ShadowEn.SetActive(true);
        tempShadowAnim.Play("Z_Idle");
        yield return new WaitForSeconds(4.0f);
        ShadowEn.GetComponent<Transform>().LookAt(Player.GetComponent<Transform>());
        tempShadowAud.Play();
        tempShadowAud2.Play();
       //Player.GetComponent<FirstPersonController>().enabled = false;
       yield return new WaitForSeconds(1.0f);
        tempShadowAnim.Play("Z_Run");
        ShadowEn.GetComponent<Transform>().localScale = new Vector3(1.6f, 1.4f, 1.6f);
        ShadowEn.transform.position = Vector3.MoveTowards(currentPos, Player.transform.position, 2f);
        yield return new WaitForSeconds(1.5f);
        tempShadowAud.Stop();
        tempShadowAud2.Stop();
     ShadowEn.SetActive(false);


        lightOb.GetComponent<Light>().intensity = 2.0f;
        lightOb2.GetComponent<Light>().intensity = 2.0f;
        //lightOb3.GetComponent<Light>().intensity = 2.0f;
        //lightOb4.GetComponent<Light>().intensity = 2.0f;

        lightOb.SetActive(true);
       // lightOb3.SetActive(true);
        //lightOb4.SetActive(true);

        //Player.GetComponent<FirstPersonController>().enabled = true;
        DoorSetting.GetComponent<DoorOpenCtrl>().isLock = false;
        playerScareSound.Play();

        //2.tempLightAnim.Stop();
        tempLightAnim2.Stop();
        //1.tempLightAnim3.Stop();
        //3.tempLightAnim4.Stop();
        tempLightAud.Stop();

        yield return new WaitForSeconds(8.0f);
        TempText.text = "- 내가 지금 피곤해서 미친건가?";
        yield return new WaitForSeconds(2.0f);
        TempText.text = "";
       
        NextDayOb.SetActive(true);
    }
}
