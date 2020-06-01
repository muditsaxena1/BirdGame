using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ProfileChange : MonoBehaviour
{
    public PostProcessProfile city;
    public PostProcessProfile ocean;
    private PostProcessVolume _ppv;
    public Material outsideSkybox;
    public Material underwaterSkybox;
    

    // Start is called before the first frame update
    void Start()
    {
        _ppv = FindObjectOfType<PostProcessVolume>();
    }

    // Update is called once per frame
    
         void OnTriggerEnter(Collider other)
        {
            if (other.tag=="MainCamera")
            {
            Debug.Log("Entered Collider");
                _ppv.profile = ocean;
            RenderSettings.skybox = underwaterSkybox;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag=="MainCamera")
            {
                Debug.Log("Exited Collider");
            _ppv.profile = city;
            RenderSettings.skybox = outsideSkybox;
            }
        }
    

   
}
