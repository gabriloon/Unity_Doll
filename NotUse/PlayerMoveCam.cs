using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCam : MonoBehaviour
{
    public Camera cam;
    public float rotSp = 3.0f;
    public float moveSp = 5.0f;
    float rotY, rotX;
    public float minCl = -45.0f, maxCl = 45.0f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        moveCtrl();
        rotCtrl();
        //rotateCamera();
    }

    private void moveCtrl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * moveSp * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * moveSp * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSp * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSp * Time.deltaTime);
        }
    }

    private void rotCtrl()
    {
        rotX += Input.GetAxis("Mouse Y") * rotSp;
        rotX = Mathf.Clamp(rotX, minCl, maxCl);
        rotY = Input.GetAxis("Mouse X") * rotSp;
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
    }


}