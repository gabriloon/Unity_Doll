using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSave : MonoBehaviour
{
    public GameObject player;
   

    public void SaveData()
    {
        Debug.Log("저장");
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.SetInt("Room1Clear", KeyCheck.Room1);
        PlayerPrefs.SetInt("Room2Clear", KeyCheck.Room2);
        PlayerPrefs.SetInt("Room3Clear", KeyCheck.Room3);
        PlayerPrefs.SetInt("InnerFoot", KeyCheck.isInOut);
        PlayerPrefs.SetInt("FirstDoorOpen", KeyCheck.isFirstDoor);
        PlayerPrefs.SetInt("SecondDoorOpen", KeyCheck.isSecondDoor);

        PlayerPrefs.Save();

    }


    public void LoadData() {
        if (!PlayerPrefs.HasKey("PlayerX"))
        {
            return;
        }

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float z = PlayerPrefs.GetFloat("PlayerZ");

        KeyCheck.playerPos = new Vector3(x, y, z);

        KeyCheck.Room1 = PlayerPrefs.GetInt("Room1Clear");
        KeyCheck.Room2 = PlayerPrefs.GetInt("Room2Clear");
        KeyCheck.Room3 = PlayerPrefs.GetInt("Room3Clear");
        KeyCheck.isInOut = PlayerPrefs.GetInt("InnerFoot");
        KeyCheck.isFirstDoor = PlayerPrefs.GetInt("FirstDoorOpen");
        KeyCheck.isSecondDoor = PlayerPrefs.GetInt("SecondDoorOpen");

    }

    public void DeleteData() {
        PlayerPrefs.DeleteAll();
    }
}


