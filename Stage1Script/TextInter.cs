using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInter : MonoBehaviour
{
    public GameObject Player;
    public GameObject Interaction;
    public GameObject Aim;
    public GameObject playerSpe;
    public int isOb;
    private Text playerText;

    private float Distance;
    private AudioSource bell;
    private void Start()
    {
        playerText = playerSpe.GetComponent<Text>();
    }


    private void OnMouseOver()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if (Distance < 2.5f)
        {
            Interaction.SetActive(true);
            Aim.SetActive(false);
            if (Input.GetButtonDown("Interaction"))
            {
                StartCoroutine(ObjectInfo());
            }
        }

        else
        {
            Interaction.SetActive(false);
            Aim.SetActive(true);
        }

    }
    void OnMouseExit()
    {
        Interaction.SetActive(false);
        Aim.SetActive(true);
    }
    IEnumerator ObjectInfo()
    {
        if (isOb == 0)
        {
            playerText.text = "잘 안 쓰긴 하지만 요리를 하기 위한 도구들";
        }
        else if (isOb == 1)
        {
            playerText.text = "선물로 받은 년도를 기억하는 큐브";
        }
        else if (isOb == 2)
        {
            playerText.text = "TV 리모콘, 별로 보고싶은 마음이 안든다.";
        }
        else if (isOb == 4)
        {
            playerText.text = "가져 오긴 했지만 기분 나쁜 인형....";
        }
        else {

        }
            yield return new WaitForSeconds(2.0f);
        playerText.text = "";
    }
}
