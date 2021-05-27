using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    public AudioSource CloseSound;
    private bool CloseD = true;
    private Animation tempAnim;
    // Start is called before the first frame update
    void Start()
    {
        tempAnim = TheDoor.GetComponent<Animation>();
    }
    void OnMouseOver()
    {//마우스 올라갔을때

        TheDistance = PlayRay.DistanceFromTarget;
    

        if (TheDistance <= 3.0f && CloseD)
        {
            //ActionText.GetComponent<Text>().text = "Open";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            //Debug.Log("통과2");
        }
        else if ((TheDistance <= 3.0f) && !CloseD) {
            //ActionText.GetComponent<Text>().text = "Close";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Interaction"))
        {
            //Debug.Log("통과3");
            if (TheDistance <= 3.0f && CloseD)
            {
                //this.GetComponent<BoxCollider>().enable=false;
               // ActionText.GetComponent<Text>().text = "Close";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);

                tempAnim.Play("WindowUpAnim");
                CreakSound.Play();
                CloseD = false;
            
            }
            else if ((TheDistance <= 3.0f) && !CloseD)
            {
                //this.GetComponent<BoxCollider>().enabled = false;
               // ActionText.GetComponent<Text>().text = "Open";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
                tempAnim.Play("WindowDownAnim");//닫히는 애니메이션
                CloseSound.Play();
                CloseD = true;
               
            }
        }
    }


    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
