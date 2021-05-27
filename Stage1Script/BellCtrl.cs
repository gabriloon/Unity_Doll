using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCtrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Interaction;
    public GameObject Aim;
    //public AudioSource Bell;


    private float Distance;
    private AudioSource bell;
    private void Start()
    {
        bell = this.GetComponent<AudioSource>();
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
                StartCoroutine(BellSound());
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
    IEnumerator BellSound()
    {
        bell.Play();
         yield return new WaitForSeconds(3.0f);

    }
}
