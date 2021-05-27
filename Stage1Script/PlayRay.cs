using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRay : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float ToTarget;
    // Start is called before the first frame update
    //private int layerMask;  
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit,20.0f))
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
