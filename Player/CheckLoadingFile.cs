using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLoadingFile : MonoBehaviour
{//PlayerSave Script 와 연계
    public GameObject loadText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            loadText.SetActive(true);
        }

    }
}
