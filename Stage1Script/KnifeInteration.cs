using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class KnifeInteration : MonoBehaviour
{

    public GameObject InterIcon;
    public GameObject Aim;

    public GameObject Knife;

    private float dist;
    void OnMouseOver()
    {

        dist = PlayRay.DistanceFromTarget;
        if (dist <= 4.0)
        {

            InterIcon.SetActive(true);
            Aim.SetActive(false);

            if (Input.GetButtonDown("Interaction"))
            {
                StartCoroutine(dollClear());
            }

        }
    }

    IEnumerator dollClear()
    {
 
        Knife.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = false;
        InterIcon.SetActive(false);
        Aim.SetActive(true);
        KeyCheck.haveKnife = true;
        yield return null;
    }

    void OnMouseExit()
    {
        InterIcon.SetActive(false);
        Aim.SetActive(true);
    }
}
