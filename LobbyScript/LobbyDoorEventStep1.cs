using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDoorEventStep1 : MonoBehaviour
{
    public GameObject doorCloseTrig;
    private void OnTriggerEnter()
    {
        doorCloseTrig.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
