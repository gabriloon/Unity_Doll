using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class CreateToGhostEvent : MonoBehaviour
{
    public GameObject InterIcon;
    public GameObject Aim;
    public GameObject FadeSc;
    public GameObject ObjectInfo;

    public GameObject Player;
    //public GameObject Knife;
    public GameObject Door;
    public GameObject DoorSetting;
    public AudioSource doorSound;

    public GameObject NightOb;
    public GameObject NightNot;
    public GameObject Fripan;
    public GameObject bath;


    public AudioSource knifeHeat;
    public AudioSource GhostSound1;
    public AudioSource heartBeat;
    
    public AudioSource NightSound;
    public AudioSource GhostShot;


    public GameObject dollMesh;
    private float dist;
    private Animation tempAnim;
    private Text tempText;
    private Animation anim1;

    public GameObject Tv1;
    public GameObject Tv2;

    public GameObject setDoll;
    public GameObject doll;
    public GameObject group;
    public List<Transform> wayPoints;

     public GameObject Lighter;
     public GameObject Lightergroup;
     public List<Transform> wayPoints2;
    private int setNum;
    private int setNum2;


    private void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
        tempText = ObjectInfo.GetComponent<Text>();

        anim1 = Door.GetComponent<Animation>();
    }


    void OnMouseOver()
    {

        dist = PlayRay.DistanceFromTarget;
        if (dist <= 4.0)
        {

            InterIcon.SetActive(true);
            Aim.SetActive(false);

            if (Input.GetButtonDown("Interaction"))
            {
                StartCoroutine(GetLighter());
            }

        }
    }

    IEnumerator GetLighter()
    {

        if (KeyCheck.haveKnife)//칼을 가지고 있을때
        {

            tempText.text = "찾았다.";
            tempAnim.Play("FadeScAnim2");//화면 검정 
            Player.GetComponent<FirstPersonController>().enabled = false;

            yield return new WaitForSeconds(2.0f);
            tempText.text = "";
            knifeHeat.Play();
            yield return new WaitForSeconds(2.0f);
    
            tempAnim.Play("FadeScAnim3");
            InterIcon.SetActive(false);
            Aim.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = true;
          
            heartBeat.Stop();
            GhostSound1.Stop();
            yield return new WaitForSeconds(3.0f);//

            anim1.Play("CloseTheDoor");
            doorSound.Play();
            DoorSetting.GetComponent<DoorOpenCtrl>().CloseD = true;
            DoorSetting.GetComponent<DoorOpenCtrl>().isLock = true;

            //불꺼지고

            NightOb.SetActive(true);
            NightNot.SetActive(false);
            KeyCheck.isNightmare = true;
            dollMesh.SetActive(false);
            setDoll.SetActive(true);
            Fripan.GetComponent<BoxCollider>().enabled = false;
           bath.GetComponent<BoxCollider>().enabled = false;

            if (group != null)
            {
                group.GetComponentsInChildren<Transform>(wayPoints);
                wayPoints.RemoveAt(0);
                setNum = Random.Range(0, wayPoints.Count);
            }

            doll.GetComponent<Transform>().position = wayPoints[setNum].position;
            //인형 위치 배치.

            if (Lightergroup != null)
            {
                Lightergroup.GetComponentsInChildren<Transform>(wayPoints2);
                wayPoints2.RemoveAt(0);
                setNum2 = Random.Range(0, wayPoints2.Count);
            }
            Lighter.GetComponent<Transform>().position = wayPoints2[setNum2].position;

            yield return new WaitForSeconds(3.0f);//
            //괴물소리
            GhostShot.Play();

               yield return new WaitForSeconds(3.0f);//
            DoorSetting.GetComponent<DoorOpenCtrl>().isLock = false;
            heartBeat.Play();
            NightSound.Play();

            Tv1.SetActive(true);
            Tv2.SetActive(true);
        }
        else//칼을 들고 있지 않았을시에
        {
            tempText.text = "찌르기 위한 날카로운 물건이 필요하다";
            yield return new WaitForSeconds(2.0f);
            tempText.text = "";

        }

        InterIcon.SetActive(false);
        Aim.SetActive(true);
    }



    void OnMouseExit()
    {
        InterIcon.SetActive(false);
        Aim.SetActive(true);
    }
}
