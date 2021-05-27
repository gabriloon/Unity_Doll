using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class PreDollInte : MonoBehaviour
{

    public GameObject InterIcon;
    public GameObject Aim;

    public GameObject dollMesh;

    private float dist;
    void OnMouseOver()
    {

        dist = PlayRay.DistanceFromTarget;
        if (dist <= 4.2)
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
            KeyCheck.haveDoll = true;
            dollMesh.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
        InterIcon.SetActive(false);
        Aim.SetActive(true);

        yield return null;
    }

    void OnMouseExit()
    {
        InterIcon.SetActive(false);
        Aim.SetActive(true);
    }
}
