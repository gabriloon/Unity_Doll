using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCtrl : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    //public GameObject ActionText;
    public GameObject TheDoor;
  
    public AudioSource CreakSound;
    public AudioSource CloseSound;
    private bool CloseD = true;
    private Animation tempAnim;
    // Start is called before the first frame update

    private void Start()
    {
        tempAnim = TheDoor.GetComponent<Animation>();
    }

    void OnMouseOver()
    {//마우스 올라갔을때
        TheDistance = PlayRay.DistanceFromTarget;

        if (TheDistance <= 5.0f && CloseD)
        {
            ActionDisplay.SetActive(true);
        }
        else if ((TheDistance <= 5.0f) && !CloseD)
        {
            ActionDisplay.SetActive(true);
        }


        if (Input.GetButtonDown("Interaction"))
        {
            if (TheDistance <= 5.0f && CloseD)
            {
                ActionDisplay.SetActive(true);
                tempAnim.Play("DrawerAnim");//열리는 애니메이션
                CreakSound.Play();
                CloseD = false;

            }
            else if ((TheDistance <= 5.0f) && !CloseD)
            {
                ActionDisplay.SetActive(true);
                tempAnim.Play("DrawerCloseAnim");//닫히는 애니메이션
                CloseSound.Play();
                CloseD = true;

            }
        }
    }


    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
    }
}