using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class DollInteraction : MonoBehaviour
{

    public GameObject InterIcon;
    public GameObject Aim;
    public GameObject InformationText;
    public GameObject FadeSc;

    public GameObject Player;
    public GameObject enemy;
    public AudioSource enemySound;
    public GameObject dollMesh;
    public GameObject fire;

    public AudioSource lighter1;
    public AudioSource lighter2;

    private Animation tempAnim;
    private float dist;
    private Text tempText;


    // Start is called before the first frame update
    void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
        tempText = InformationText.GetComponent<Text>();
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
                StartCoroutine(dollClear());
            }

        }
    }

    IEnumerator dollClear() {
        if (KeyCheck.haveLighter)
        {
            enemy.SetActive(false);
            enemySound.Stop();
            this.GetComponent<BoxCollider>().enabled = false;

            lighter1.Play();
            yield return new WaitForSeconds(1.0f);
            lighter2.Play();
            yield return new WaitForSeconds(1.0f);

            dollMesh.SetActive(true);
            this.transform.position = Player.transform.position + new Vector3(0f, -0.5f, 0f);
            fire.SetActive(true);
            //라이터 키는 음성 재생과 라이터 효과
            //인형 불로 타는 모습 인형에 paticle 효과 추가하는거지
            yield return new WaitForSeconds(6.0f);
            tempAnim.Play("FadeScAnim2");//화면 검정 
       
            
            yield return new WaitForSeconds(2.0f);
        
            KeyCheck.Room1 = 1;//Doll Story 클리어
            KeyCheck.isNightmare = false;
            KeyCheck.phoneKey = false;
            KeyCheck.haveDoll = false;
            KeyCheck.haveKnife = false;
            KeyCheck.haveLighter = false;


            SceneManager.LoadScene(1);
            fire.SetActive(false);
        }
        else {
            tempText.text = "태울려면 라이터가 필요하다.";
            KeyCheck.haveDoll = true;
            dollMesh.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;

            yield return new WaitForSeconds(3.0f);
            tempText.text = "";
            //인형 챙기고 
        }

        InterIcon.SetActive(false);
        Aim.SetActive(true);
        //라이터를 가지고 있을시 바로 태우기 가능 , 반대로 가지고 있지 않을시 가지러 가야된다.

    }

   void OnMouseExit()
    {
        InterIcon.SetActive(false);
        Aim.SetActive(true);
    }
}
