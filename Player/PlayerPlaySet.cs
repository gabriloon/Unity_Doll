using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerPlaySet : MonoBehaviour
{

    public GameObject EscImage;
    private bool showing;
    public GameObject Player;
    public GameObject infoText;

    private Animation tempAnim;

    // Start is called before the first frame update
    void Start()
    {
        tempAnim = infoText.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {//ESC 키 입력 감지

            if (showing)
            {
                EscImage.SetActive(false);
                showing = !showing;
                Player.GetComponent<FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else {
                EscImage.SetActive(true);
                Player.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                showing = !showing;
            }

            }
        
    }

    public void GameExit() {//종료

        Application.Quit();
    }

    public void SaveInfo() {//저장시 텍스트 애니메이션
        tempAnim.Play();
    }


    public void GoStartScene() {
        //메인씬으로 돌아가시겠습니까?
        //버튼 선택음 필요
        SceneManager.LoadScene(0);
    }
}
