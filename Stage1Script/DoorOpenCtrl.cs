using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenCtrl : MonoBehaviour
{
    public float TheDistance;
    public GameObject Player;
    //public GameObject ActionDisplay;
    //public GameObject InformationText;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    public AudioSource CloseSound;
   public bool CloseD = true;
    public bool isLock = false;
    //private float timer = 0f;
    private Animation tempAnim;
    // Start is called before the first frame update
    void Start()
    {
        tempAnim = TheDoor.GetComponent<Animation>();
    }

    void OnMouseOver()
    {//마우스 올라갔을때
     TheDistance = Vector3.Distance(Player.transform.position,this.transform.position);
        //TheDistance = PlayRay.DistanceFromTarget;
        
        Debug.Log(TheDistance);
        if (TheDistance <= 5.0f && CloseD)
        {
           // ActionDisplay.GetComponent<Text>().text = "Open";
           // ActionDisplay.SetActive(true);
            //ActionText.SetActive(true);
            //Debug.Log("통과2");
        }
        else if ((TheDistance <= 5.0f) && !CloseD)
        {
           // ActionDisplay.GetComponent<Text>().text = "Close";
            //ActionDisplay.SetActive(true);
            //ActionText.SetActive(true);

        }
        StartCoroutine(waitDoor());

    }

    IEnumerator waitDoor() {
        if (Input.GetButtonDown("Interaction"))
        {
            //Debug.Log("통과3");
            if (TheDistance <= 5.0f && CloseD)
            {
                //this.GetComponent<BoxCollider>().enable=false;
                // ActionDisplay.GetComponent<Text>().text = "Close";
               // ActionDisplay.SetActive(true);
                if (!isLock)
                {
                    tempAnim.Play("OpenTheDoor");
                    CreakSound.Play();
                    CloseD = false;
                }
                else
                {
                  // InformationText.GetComponent<Text>().text = "열리지 않는다.";
                    yield return new WaitForSeconds(2.0f);
                  //  InformationText.GetComponent<Text>().text = "";
                }
            }
            else if ((TheDistance <= 5.0f) && !CloseD)
            {
               
                //this.GetComponent<BoxCollider>().enabled = false;
                //ActionDisplay.GetComponent<Text>().text = "Open";
              //  ActionDisplay.SetActive(true);
                // ActionText.SetActive(true);
                tempAnim.Play("CloseTheDoor");//닫히는 애니메이션
                CloseSound.Play();
                CloseD = true;
            }
            yield return new WaitForSeconds(2.0f);
        }
    }
    /*
    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }*/
}

