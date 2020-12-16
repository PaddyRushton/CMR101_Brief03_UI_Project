using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CountDownTimer : MonoBehaviour
{
    PostProcessVolume currentPostProcessVolume;
    Vignette radioactivityVignette;
    //MotionBlur radioactivityMotionBlur;
    Bloom radioactivityBloom;
    private float vignetteValue = 0;
    //private float motionBlurValue = 0;
    private float bloomValue = 0 ;
    private float totalGameTime = 80;

    void Start()
    {
        radioactivityVignette = ScriptableObject.CreateInstance<Vignette>();
        radioactivityVignette.enabled.Override(true);
        radioactivityVignette.intensity.Override(1f);
        radioactivityVignette.smoothness.Override(10f);

       /* radioactivityMotionBlur = ScriptableObject.CreateInstance<MotionBlur>();
        radioactivityMotionBlur.enabled.Override(true);
        radioactivityMotionBlur.shutterAngle.Override(1f);
        */

        radioactivityBloom = ScriptableObject.CreateInstance<Bloom>();
        radioactivityBloom.enabled.Override(true);
        radioactivityBloom.intensity.Override(1f);
        currentPostProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, radioactivityVignette, radioactivityBloom);
    }


    void Update()
    {
        UpdatePostProcessValues();
    }
     

    void UpdatePostProcessValues()
    {
        vignetteValue = (0.00001f/totalGameTime*(Mathf.Pow(Time.realtimeSinceStartup, 3)));
        //Debug.Log("Vignette Value" + radioactivityVignette.intensity.value);
        radioactivityVignette.intensity.value = vignetteValue;


        /*while (motionBlurValue < 3.6)
        {
            motionBlurValue = (0.1f*Time.realtimeSinceStartup);
            Debug.Log("Motion Blur Value" + radioactivityMotionBlur.shutterAngle.value);
            radioactivityMotionBlur.shutterAngle.value = motionBlurValue;
        }
        */

        bloomValue = (0.00001f / totalGameTime * (Mathf.Pow(Time.realtimeSinceStartup, 4f)));
        //Debug.Log("Bloom Value" + radioactivityBloom.intensity.value);
        radioactivityBloom.intensity.value = bloomValue;

    }
}
