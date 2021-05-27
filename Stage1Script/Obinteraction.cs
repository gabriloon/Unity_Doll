using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class Obinteraction : MonoBehaviour
{//RigidBody의 컴포넌트가 있는 들고 싶은 물체에다가 이 Script를 넣는다.

    public Transform theDest;//플레이어하위로 오브젝트 생성후(이름을 Destination) 에 위치를 플레이어 바로 앞으로 놔둔다. 
    private Vector3 initPos;
    private float Distance;
    public GameObject Player;
    public GameObject Interaction;
    public GameObject Aim;
    public GameObject playerSpe;

    private PostProcessProfile postProfile;
    public float changeValue = 1.0f;
    public float initValue = 10.0f;
    public GameObject postObject;
    public bool isInput;
public bool isJikkak;
    private Text playerText;

    public int CheckOb;
    float rotationSpeed = 3.5f;
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;


    private void Start()
    {
        postProfile = postObject.GetComponent<PostProcessVolume>().profile;
        initPos = this.GetComponent<Transform>().position;
        playerText = playerSpe.GetComponent<Text>();
    }

    private void OnMouseOver()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if (Distance < 2.5f)
        {
            Interaction.SetActive(true);
            Aim.SetActive(false);
            if (Input.GetButtonDown("Interaction")) {
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
    IEnumerator ObjectLook() {
        if (isInput)
        {
            this.transform.position = initPos;
            postProfile.GetSetting<DepthOfField>().focusDistance.value = initValue;
            Player.GetComponent<FirstPersonController>().enabled = true;
            Aim.SetActive(true);
            if (isJikkak)
            {
                this.GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
            }
            else { this.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0); }
            playerText.text = "";

            // Interaction.SetActive(true);

        }
        else {
            Player.GetComponent<FirstPersonController>().enabled = false;
            this.transform.position = theDest.position;
            postProfile.GetSetting<DepthOfField>().focusDistance.value = changeValue;
            Aim.SetActive(false);
            Interaction.SetActive(false);
            if (CheckOb == 0)
            {
                playerText.text = "여러가지 오컬트적인 사건이 적혀져 있는 책/라면받침대";
            }
            else if (CheckOb == 1) {
                playerText.text = "선물로 받은 특이한 물건";
            }
            else if (CheckOb == 2)
            {
                playerText.text ="잡지";
            }
            else if (CheckOb == 3)
            {
                playerText.text = "해외여행 갔을때 구매한 큐브";
            }
            else if (CheckOb == 4)
            {
                playerText.text = "파일철";
            }
            else if (CheckOb == 6)
            {
                playerText.text = "잡지들";
            }
            else if (CheckOb == 7)
            {
                playerText.text = "여러가지 물건들을 보관하는 상자";
            }
        }
        isInput = !isInput;
        yield return null;
    }


    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        if (isInput)
        {
            transform.Rotate(Vector3.forward, XaxisRotation);
            transform.Rotate(Vector3.left, YaxisRotation);
        }
    }
    


}

