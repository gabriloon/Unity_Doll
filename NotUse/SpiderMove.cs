using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    public Transform trans;
 
    //public Transform resPos;
    //
    Vector3 velo = Vector3.zero;
    void Update() {
        //transform.Translate(Vector3.forward * 0.03f);
        transform.position = Vector3.SmoothDamp(transform.position, trans.position, ref velo, 7.0f);
    }


}
