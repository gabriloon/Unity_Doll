using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public GameObject theLightOb;
    //public GameObject thoDoll;
    //public GameObject telePos;
    //public GameObject bedOb;
    public AudioSource tempAudio;
    private Animation tempAnim;
    // Start is called before the first frame update
    void Start()
    {
        tempAnim = theLightOb.GetComponent<Animation>();
    }

   void OnTriggerEnter()
    {
        tempAnim.Play("LightOffOn");//스탠드 꺼지고 켜지는 애니메이션 재생
        this.GetComponent<BoxCollider>().enabled = false;//이벤트를 발생시킨 다음에 제외
        tempAudio.Play();//스탠드 꺼지고 켜지는 소리 재생 깜빡깜빡 소리
    }

}
