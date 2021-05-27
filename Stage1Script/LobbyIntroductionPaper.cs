using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class LobbyIntroductionPaper : MonoBehaviour
{
    //첫번째 방식 Trigger 형식으로 물건을 집었을경우 screen 을 깜빡깜빢하게 해주면서 꺼졌다 켜지는 음성 재생 
    //그리고 자연스럽게 Mesh Renderer 를 변경해주는거다.
    //아니면 집는 Script를 가진 오브젝트 하위로 오브젝트를 덮어놓고 
    // false 로 해놓는다 그리고 나중에 true로 변경해줘서 바뀐것처럼 보여주거나  
    public Transform theDest;//플레이어하위로 오브젝트 생성후(이름을 Destination) 에 위치를 플레이어 바로 앞으로 놔둔다. 
    private Vector3 initPos;
    private float Distance;
    public GameObject Player;
    public GameObject Interaction;

    public GameObject Aim;
    public GameObject PaperCanvas;

    private PostProcessProfile postProfile;


    public float changeValue = 1.0f;
    public float initValue = 10.0f;
    public GameObject postObject;
    public bool isInput;
    float rotationSpeed = 3.5f;


    public GameObject DoorL;
    public GameObject DoorR;

    private Animation tempAnim1;
    private Animation tempAnim2;

    public AudioSource doorAud;

    private void Start()
    {
        postProfile = postObject.GetComponent<PostProcessVolume>().profile;
        initPos = this.GetComponent<Transform>().position;
        tempAnim1 = DoorL.GetComponent<Animation>();
        tempAnim2 = DoorR.GetComponent<Animation>();
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

                    StartCoroutine(ObjectLook());
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
    IEnumerator ObjectLook()
    {
        if (isInput)
        {
            if (KeyCheck.isSecondDoor!=1)
            {
                tempAnim1.Play("MainDoorLAnim");
                tempAnim2.Play("MainDoorRAnim");
                doorAud.Play();
                KeyCheck.isSecondDoor = 1;
            }

            this.transform.position = initPos;
            postProfile.GetSetting<DepthOfField>().focusDistance.value = initValue;
            Player.GetComponent<FirstPersonController>().enabled = true;
            PaperCanvas.SetActive(false);
            Aim.SetActive(true);
           // this.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);//

        }
        else
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            this.transform.position = theDest.position;
            postProfile.GetSetting<DepthOfField>().focusDistance.value = changeValue;
            PaperCanvas.SetActive(true);
            Aim.SetActive(false);
            Interaction.SetActive(false);

        }
        isInput = !isInput;
        yield return null;
    }


}


