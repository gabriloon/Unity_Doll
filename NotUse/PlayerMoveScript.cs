using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMoveScript : MonoBehaviour
{
    public Camera cam;
    public float rotSp = 3.0f;
    public float moveSp = 1.0f;
    float rotY,rotX;
    public float minCl = -45.0f, maxCl=45.0f;
    public Animator m_Animator;
    bool m_walk;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCtrl();
        rotCtrl();
        //rotateCamera();
    }

    private void moveCtrl() {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {

            this.transform.Translate(Vector3.forward * moveSp * Time.deltaTime);
            m_Animator.SetBool("isWalk", true);
            m_Animator.SetBool("isRun", true);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * moveSp/2 * Time.deltaTime);
            m_Animator.SetBool("isWalk", true);
           
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * moveSp/3 * Time.deltaTime);
            m_Animator.SetBool("isWalk", true);
           
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSp/3 * Time.deltaTime);
            m_Animator.SetBool("isWalk", true);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSp/3 * Time.deltaTime);
            m_Animator.SetBool("isWalk", true);
        }
        else
        {
            m_Animator.SetBool("isWalk", false);
            m_Animator.SetBool("isRun", false);
        }
    }

    private void rotCtrl() {
        rotX += Input.GetAxis("Mouse Y") * rotSp;
         rotX = Mathf.Clamp(rotX, minCl, maxCl);
   rotY = Input.GetAxis("Mouse X") * rotSp;
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
    }

  
}

