using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class PaperInteraction1 : MonoBehaviour
{
    //첫번째 방식 Trigger 형식으로 물건을 집었을경우 screen 을 깜빡깜빢하게 해주면서 꺼졌다 켜지는 음성 재생 
    //그리고 자연스럽게 Mesh Renderer 를 변경해주는거다.
    //아니면 집는 Script를 가진 오브젝트 하위로 오브젝트를 덮어놓고 
    // false 로 해놓는다 그리고 나중에 true로 변경해줘서 바뀐것처럼 보여주거나  
    public Transform theDest;//플레이어하위로 오브젝트 생성후(이름을 Destination) 에 위치를 플레이어 바로 앞으로 놔둔다. 
    private Vector3 initPos;
    private float Distance;
    public GameObject Player;
    public GameObject playerSpe;
    public GameObject Interaction;
    public GameObject NextTrigger;
    public GameObject Aim;
    public GameObject Chair;
    private PostProcessProfile postProfile;
  private Text playerText;

    public float changeValue = 1.0f;
    public float initValue = 10.0f;
    public GameObject postObject;
    public bool isInput;
    public bool isFirst;
    float rotationSpeed = 3.5f;
   


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
            this.transform.position = initPos;
            postProfile.GetSetting<DepthOfField>().focusDistance.value = initValue;
            Player.GetComponent<FirstPersonController>().enabled = true;
            Aim.SetActive(true);
            this.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            playerText.text = "";
            if (!isFirst)
            {
                Chair.GetComponent<Rigidbody>().useGravity = false;
                Chair.GetComponent<Rigidbody>().AddForce(transform.forward*70.0f );//UseGravity가 문제였어
               // chairTrans.position = Vector3.MoveTowards(chairTrans.position, Despos, 1.0f * Time.deltaTime);
                Chair.GetComponent<AudioSource>().Play();
                isFirst = true;
                NextTrigger.SetActive(true);
                //Chair.GetComponent<Rigidbody>().useGravity = true;
            }

            // Interaction.SetActive(true);

        }
        else
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            this.transform.position = theDest.position;
            postProfile.GetSetting<DepthOfField>().focusDistance.value = changeValue;
            Aim.SetActive(false);
            Interaction.SetActive(false);
            playerText.text = "아무것도 적혀 있지 않은 종이다.";
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


