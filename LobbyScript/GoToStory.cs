using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GoToStory : MonoBehaviour
{

    public GameObject Player;
    public int stageNum;//이동할 Scene 번호.
    void OnTriggerEnter()
    { 
            Player.GetComponent<FirstPersonController>().enabled = false;//플레이어 움직임 정지.
        KeyCheck.playerPos = Player.GetComponent<Transform>().position;//Scene 이동전에 위치 확인.
        KeyCheck.startRoom = stageNum; //이동할 Scene 번호 Static 으로 저장
        SceneManager.LoadScene(2);//이동
    }

}
