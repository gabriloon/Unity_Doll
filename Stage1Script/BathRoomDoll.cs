using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class BathRoomDoll : MonoBehaviour
{
    public GameObject InterIcon;
    public GameObject Aim;
    public GameObject FadeSc;
    public GameObject ObjectInfo;
    public GameObject tubDollPos;
    public GameObject afterTrig;

    public GameObject Player;

    public GameObject waterOb;
    public AudioSource waterTub;
    public GameObject dollMesh;//인형 위치 this.transform 으로 이동
    private float dist;
    private Animation tempAnim;
    private Text tempText;

    private void Start()
    {
        tempAnim = FadeSc.GetComponent<Animation>();
        tempText = ObjectInfo.GetComponent<Text>();
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

        if (KeyCheck.haveDoll)//인형을 가져 왔는가
        {
           waterTub.Play();//물소리
            tempAnim.Play("FadeScAnim2");//화면 검정 
            Player.GetComponent<FirstPersonController>().enabled = false;//플레이어 움직임 정지
        
            dollMesh.transform.position = tubDollPos.transform.position;//인형 위치 욕조로 이동
            yield return new WaitForSeconds(7.0f);

            dollMesh.SetActive(true);
            waterOb.SetActive(true);//물 
            waterTub.Stop();
          
            tempAnim.Play("FadeScAnim3");//화면 다시 보이게 돌아오고

          
            InterIcon.SetActive(false);
            Aim.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = true;//다시 움직이게 설정
            KeyCheck.haveDoll = false;
            //자기 이름 말하고 
            yield return new WaitForSeconds(2.0f);
            tempText.text = "***";//그냥 이름만 말하면 이상해서 ***로 현재는 표시
            yield return new WaitForSeconds(2.0f);
            tempText.text = "거실로 돌아가자.";
            afterTrig.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            tempText.text = "";
        
        }
        else
        {
            tempText.text = "인형이 필요하다.";
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
