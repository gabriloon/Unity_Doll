using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCheck : MonoBehaviour
{
    public float TimeCost = 10;

    public GameObject textUI;

    private Text tempText;
    // Start is called before the first frame update
    void Start()
    {
        tempText = textUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()//10초 카운트
    {
        TimeCost -= Time.deltaTime;
        tempText.text = "" + (int)TimeCost;
    }
}
