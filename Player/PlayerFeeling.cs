using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeeling : MonoBehaviour
{

    public Transform Camera;
    public bool shakeRotate;
    private Vector3 originPos;
    private Quaternion originRot;

  

    // Start is called before the first frame update
    void Start()
    {
        originPos = Camera.localPosition;
        originRot = Camera.localRotation;
        
    }

    private void Update()
    {
       if(Input.GetButtonDown("Interaction")){
            Debug.Log("E키");
            StartCoroutine(shakingCam());
        }
    }

    public IEnumerator shakingCam(float duration = 0.5f, float movePos = 0.001f, float moveRot = 0.01f) 
    {
        float passTime = 0.0f;
        while (passTime < duration)
        {
            Vector3 shakePos = Random.insideUnitSphere;
            Camera.localPosition = shakePos * movePos;

            if (shakeRotate) {
                Vector3 shakeRot = new Vector3(0, 0, Mathf.PerlinNoise(Time.time * moveRot, 0.0f));
                Camera.localRotation = Quaternion.Euler(shakeRot);
            }

            passTime += Time.deltaTime;
            yield return null;
        }
        Camera.localPosition = originPos;
        Camera.localRotation = originRot;
    }



}
