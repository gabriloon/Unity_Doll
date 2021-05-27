using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class footstepChange : MonoBehaviour
{//LobbyDoorEvent 와 연계
    public GameObject Player;
    public AudioClip step1;//왼발 소리
    public AudioClip step2;//오른발 소리

    public GameObject footStepOb;//발걸음 소리 배열

    public int SetIndex;

    public void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<FirstPersonController>().m_FootstepSounds[0] = step1;//소리 변경
        Player.GetComponent<FirstPersonController>().m_FootstepSounds[1] = step2;
        this.GetComponent<BoxCollider>().enabled = false;//현재 Collider
        footStepOb.GetComponent<BoxCollider>().enabled = true;//발걸음 소리 다시 바꾸기 위한 Collider
        KeyCheck.isInOut = SetIndex;//KeyCheck 로 소리 뭔지 저장.
    }
}
