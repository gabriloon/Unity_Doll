using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyDoorOpen : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject Player;
    public GameObject InformationText;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    public AudioSource CloseSound;
    public bool CloseD = true;
    private Animation tempAnim;
    private Transform playerTr;
    private Transform thisTr;
    void Start()
    {
        tempAnim = TheDoor.GetComponent<Animation>();
        playerTr = Player.GetComponent<Transform>();
        thisTr = this.GetComponent<Transform>();
    }

    void OnMouseOver()
    {
        TheDistance = Vector3.Distance(playerTr.position, thisTr.position);
        Debug.Log(TheDistance);
        if (TheDistance <= 4.0f)
        {

            ActionDisplay.SetActive(true);

            if (Input.GetButtonDown("Interaction"))
            {
                if (CloseD)
                {
                    StartCoroutine(waitDoor());

                }
                else if (!CloseD)
                {
                   // StartCoroutine(CloseDoor());
                }
            }
        }

    }

    IEnumerator waitDoor()
    {       tempAnim.Play("MainDoorRAnim");
            CreakSound.Play();
            CloseD = false;
            yield return new WaitForSeconds(2.0f);
        }
    


IEnumerator CloseDoor() {

    ActionDisplay.SetActive(true);
    tempAnim.Play("CloseTheDoor");//닫히는 애니메이션
    CloseSound.Play();
    CloseD = true;

    yield return new WaitForSeconds(2.0f);
}

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
    }
}
