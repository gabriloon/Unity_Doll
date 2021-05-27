using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartPlayerNoSound : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSpe;//플레이어 말하는거
    public GameObject AudioList;//초기에 떨어지는 소리 안들리기 위한 오디오 리스너
 
    public GameObject FadeSc;//
    private Text TempText;
    private AudioListener tempAu;
    private Animation fadeAnim;//

    void Start()//게임 시작시 잠시 플레이어가 아무소리도 안들리게 하기 위한 Script
    {
        playerSpe.SetActive(true);
        tempAu = AudioList.GetComponent<AudioListener>();
        TempText = playerSpe.GetComponent<Text>();
        fadeAnim = FadeSc.GetComponent<Animation>();
        StartCoroutine(SpeechContent1());
        
    }

    IEnumerator SpeechContent1()
    {
        tempAu.enabled = false;
        yield return new WaitForSeconds(0.5f);
        tempAu.enabled = true;
        fadeAnim.Play("FadeScAnim3");
        yield return new WaitForSeconds(5.0f);

    }
  
}