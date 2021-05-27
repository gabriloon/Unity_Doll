using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHold : MonoBehaviour
{
   
    private float Distance;
    private bool haveKey;

    public GameObject Player;
    public GameObject holdIcon;
    public GameObject showOb;
    private void Start()
    {
        //haveKey = KeyCheck.doolKey;
    }

    //이걸 겹치는 걸 없애고 간단히 할수 있는데.
    private void OnMouseOver()
    {
        Distance = PlayRay.DistanceFromTarget;


        if (!haveKey&& Distance <= 2.0f)
        {
            holdIcon.SetActive(true);
            StartCoroutine(dollHaving());
        }
        else
        {
            holdIcon.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        holdIcon.SetActive(false);
    }

    IEnumerator dollHaving()
    {
        if (Input.GetButtonDown("Interaction"))
        {
                haveKey = !haveKey;
                //KeyCheck.doolKey = true;
                holdIcon.SetActive(false);
                showOb.SetActive(false);//
            yield return new WaitForSeconds(2.0f);
        }
    }


}
