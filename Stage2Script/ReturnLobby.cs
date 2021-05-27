using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ReturnLobby : MonoBehaviour
{
    public GameObject InterIcon;
    public GameObject Aim;
    public GameObject FadeSc;


    private float dist;
    private Animation tempAnim;

    // Start is called before the first frame update
    void Start()
    {

        tempAnim = FadeSc.GetComponent<Animation>();
    }
    void OnMouseOver()
    {

        dist = PlayRay.DistanceFromTarget;
        if (dist <= 4.0)
        {

            InterIcon.SetActive(true);
            Aim.SetActive(false);

            if (Input.GetButtonDown("Interaction"))
            {
                tempAnim.Play("FadeScAnim2");
                SceneManager.LoadScene(1);

            }

        }
    }


    void OnMouseExit()
    {
        InterIcon.SetActive(false);
        Aim.SetActive(true);
    }
}
