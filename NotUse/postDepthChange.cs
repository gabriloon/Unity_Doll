using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class postDepthChange : MonoBehaviour
{
   public PostProcessProfile postProfile;
    public float changeValue;
    public float initValue;
    public GameObject postObject;

   
    // Start is called before the first frame update
    void Start()
    {
      
        postProfile = postObject.GetComponent<PostProcessVolume>().profile;

        postProfile.GetSetting<DepthOfField>().focusDistance.value = 1.0f;
    }
}
