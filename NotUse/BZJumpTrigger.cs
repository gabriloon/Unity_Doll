using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BZJumpTrigger : MonoBehaviour
{
    public AudioSource DoorJumpMusic;
    public GameObject TheZombie;
    public GameObject PlayerT;
    // Start is called before the first frame update

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        DoorJumpMusic.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayerTell());
    }
    // Update is called once per frame
    IEnumerator PlayerTell() {
        yield return new WaitForSeconds(1.0f);
        PlayerT.GetComponent<Text>().text = "무...무슨 소리지?";
        yield return new WaitForSeconds(2.0f);
        PlayerT.GetComponent<Text>().text = "";

    }
}
