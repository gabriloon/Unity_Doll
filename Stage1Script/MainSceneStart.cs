using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MainSceneStart : MonoBehaviour
{
    public GameObject fade;
    public GameObject Player;

    public GameObject PlayerAudio;
    private Animation fadeAnim;
    public AudioListener tempAu;
    public AudioSource CloseSound;
    public AudioClip step1;
    public AudioClip step2;

    public GameObject FirstDoorL;
    public GameObject FirstDoorR;
    public GameObject DoorTrig;

    private Animation tempAnim1;
    private Animation tempAnim2;

    public GameObject SecondDoorL;
    public GameObject SecondDoorR;

    private Animation tempAnim3;
    private Animation tempAnim4;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(KeyCheck.playerPos);
        fadeAnim = fade.GetComponent<Animation>();
        tempAnim1 = FirstDoorL.GetComponent<Animation>();
        tempAnim2 = FirstDoorR.GetComponent<Animation>();
        tempAnim3 = SecondDoorL.GetComponent<Animation>();
        tempAnim4 = SecondDoorR.GetComponent<Animation>();


        StartCoroutine(fadeIE());
    
    }



    IEnumerator fadeIE()
    {
        if (KeyCheck.startRoom!=0)
        {
            Player.GetComponent<Transform>().position = KeyCheck.playerPos-new Vector3(0,0,0.5f) ;
            CloseSound.Play();
           // Player.GetComponent<FirstPersonController>().m_FootstepSounds[0] = step1;
           // Player.GetComponent<FirstPersonController>().m_FootstepSounds[1] = step2;
        }
        else
        {
            if (PlayerPrefs.HasKey("PlayerX"))
            {
                Player.GetComponent<Transform>().position = KeyCheck.playerPos;
             /*   if (KeyCheck.isInOut == 1)
                {//실내일경우에는 실내발걸음 아닐경우에는 기본 set 밖에 울리는 발걸음이니 건들지 않는다.
                    Player.GetComponent<FirstPersonController>().m_FootstepSounds[0] = step1;
                    Player.GetComponent<FirstPersonController>().m_FootstepSounds[1] = step2;
                }
                */
            }
        }

        if (KeyCheck.isFirstDoor == 1) {
            tempAnim1.Play("MainDoorLAnim");
            tempAnim2.Play("MainDoorRAnim");
            DoorTrig.SetActive(false);//첫번째 입구 들어갈때 trig  체크하는 큐브

        }
        if (KeyCheck.isSecondDoor == 1)
        {
            tempAnim3.Play("MainDoorLAnim");
            tempAnim4.Play("MainDoorRAnim");
        }
        // tempAu.enabled = false;
        yield return new WaitForSeconds(2.0f);
        Player.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(2.0f);
        PlayerAudio.GetComponent<AudioListener>().enabled = true;
      
        fadeAnim.Play("FadeScAnim3");
     
    }
    }
