using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayBtn : MonoBehaviour
{

    public GameObject textBtn;
    public AudioSource btnSound;
    public void OnStartBtn()
    {
        textBtn.GetComponent<Text>().color = new Color(255, 0, 0);
        btnSound.Play();
        SceneManager.LoadScene(1);
        //StartCoroutine(startBtn());
    }
    public void GameExit()
    {
        textBtn.GetComponent<Text>().color = new Color(255, 0, 0);
        btnSound.Play();
        Application.Quit();
    }

}
