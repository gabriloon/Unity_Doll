using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class LighterGet : MonoBehaviour
{
    public GameObject InterIcon;
    public GameObject Aim;
    public GameObject FadeSc;

    public GameObject Player;
    public GameObject enemy;
    public AudioSource enemySound;

    public GameObject dollMesh;
    public GameObject doll;

    public GameObject lighter;
    public GameObject fire;
    public AudioSource lighter1;
    public AudioSource lighter2;

    private float dist;
    private Animation tempAnim;

    private void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
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

        if (KeyCheck.haveDoll) {//라이터 줍기 이전에 인형을 주었다면
            enemy.SetActive(false);//Enemy 사라지고
            enemySound.Stop();//소리도 멈추고
            lighter.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;//라이터 모습 사라지니 그에 따라 BoxCollider도 제거
            lighter1.Play();//라이터 키는 음성 재생과 라이터 효과
            yield return new WaitForSeconds(1.0f);
            lighter2.Play();
            yield return new WaitForSeconds(1.0f);
            dollMesh.SetActive(true);//인형의 모습을 보여주며
            doll.transform.position = Player.transform.position + new Vector3(0f, -0.5f, 0f);//위치를 플레이어 근처로 끌고 온다.
            fire.SetActive(true); //Particle 불로 타는 모습 
            yield return new WaitForSeconds(6.0f);
            tempAnim.Play("FadeScAnim2");//화면 검정 


            yield return new WaitForSeconds(2.0f);
            fire.SetActive(false);
            KeyCheck.Room1 = 1;//클리어
            KeyCheck.isNightmare = false;//초기화
            KeyCheck.phoneKey = false;
            KeyCheck.haveDoll = false;
            KeyCheck.haveKnife = false;
            KeyCheck.haveLighter = false;

            SceneManager.LoadScene(1);//로비 Scene 으로 이동.
        }
        else {//인형을 아직 줍지 않았을 경우
            KeyCheck.haveLighter = true;//라이터 체크.
            lighter.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
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
