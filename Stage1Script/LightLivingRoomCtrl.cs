using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLivingRoomCtrl: MonoBehaviour
{
    public float TheDistance;
    //public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject LightOb;
    public GameObject LightOb2;
    public GameObject LightOb3;
    public GameObject LightOb4;

    public bool isLight = true;
    public AudioSource bc;

    private Light tempLight1;
    private Light tempLight2;
    private Light tempLight3;
    private Light tempLight4;

    public float lightF1=1.9f;
    public float lightF2=1f;

    void Start() {

        tempLight1 = LightOb.GetComponent<Light>();
        tempLight2 = LightOb2.GetComponent<Light>();
        tempLight3 = LightOb3.GetComponent<Light>();
        tempLight4 = LightOb4.GetComponent<Light>();
    }

    void OnMouseOver()
    {

        if (Input.GetButtonDown("Interaction"))
        {
            if (!KeyCheck.isNightmare)//귀신 이벤트 발생 유무 확인
            {
                if (TheDistance <= 2 && isLight)//불켜진상태시
                {
                    tempLight1.intensity = 0.0f;
                    tempLight2.intensity = 0.0f;
                    tempLight3.intensity = 0.0f;
                    tempLight4.intensity = 0.0f;

                    //LightOb2.GetComponent<Light>().intensity = 0f;
                    bc.Play();
                    isLight = false;
                    //버튼 사운드 플레이(딸깍)
                }
                else if (TheDistance <= 2 && !isLight)//불꺼진상태시
                {

                    tempLight1.intensity = lightF1;
                    tempLight2.intensity = lightF1;
                    tempLight3.intensity = lightF2;
                    tempLight4.intensity = lightF2;

                    bc.Play();
                    isLight = true;
                }
            }
            else {
                bc.Play();
            }
        }
    }
    void OnMouseExit()
    {
        //ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }


}
