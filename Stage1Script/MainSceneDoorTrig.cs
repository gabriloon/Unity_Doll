using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainSceneDoorTrig : MonoBehaviour
{
    public GameObject DoorL;
    public GameObject DoorR;

    private Animation tempAnim1;
    private Animation tempAnim2;

    public AudioSource doorAud;

    public GameObject playerSpe;

    // Start is called before the first frame update
    void Start()
    {
        tempAnim1 = DoorL.GetComponent<Animation>();
        tempAnim2 = DoorR.GetComponent<Animation>();
    }

   void OnTriggerEnter()
    {
        tempAnim1.Play("MainDoorLAnim");
        tempAnim2.Play("MainDoorRAnim");
        doorAud.Play();
        KeyCheck.isFirstDoor = 1;
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(informationTip());
    }

    IEnumerator informationTip() {

        yield return new WaitForSeconds(2.0f);
        playerSpe.GetComponent<Text>().text = "여러 사물에 접근해 E키를 통해 이용 할 수 있습니다.";
        yield return new WaitForSeconds(2.0f);
        playerSpe.GetComponent<Text>().text = "";
    }
}
