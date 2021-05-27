using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnlyMouse : MonoBehaviour
{
    public GameObject cam;

    float rotX, rotY;
    float rotSp = 1.0f;

   
    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxis("Mouse Y") * rotSp;
        rotX = Mathf.Clamp(rotX, -45.0f, 45.0f);//입력받은 값을 최소 -45 , 최대 45도 로 각도 제한
        rotY = Input.GetAxis("Mouse X") * rotSp;
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);//y축을 기준으로 회전
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0); //각도 제한하고 회전할시에 localEulerAngles 필요. 
    }
}
