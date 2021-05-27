using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySymbolShow : MonoBehaviour
{
    

        public Texture[] textures;
    public RawImage tempImage;

    public GameObject room1Ob;
    public GameObject room2Ob;

    public Text changeText;

    // Update is called once per frame
    void Start()
    {
        if (KeyCheck.startRoom == 1)
        {
            room1Ob.SetActive(true);
            changeText.text = "나홀로 숨바꼭질";
        }
        else if (KeyCheck.startRoom == 2)
        {
            room2Ob.SetActive(true);
            changeText.text = "분신사바";
        }
        else {

            changeText.text = "비 정상적인 접근";
        }

        StartCoroutine(tempLoad());
    }


    IEnumerator tempLoad() {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(KeyCheck.startRoom+2);//2는 Loading Scene의 넘버 이고, 더 하는 값은 MainScene에서 보내는 Room마다의 값.1,2,3등 
    }

    IEnumerator ImageChange()
    {
        tempImage.texture = textures[0];
        yield return new WaitForSeconds(4.0f);
        tempImage.texture = textures[1];
        yield return new WaitForSeconds(4.0f);
        tempImage.texture = textures[2];
        yield return new WaitForSeconds(4.0f);
        tempImage.texture = textures[3];
        yield return new WaitForSeconds(4.0f);
        
    }
}

