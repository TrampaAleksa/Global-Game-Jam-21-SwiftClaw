using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light lightToFade;
    [NonSerialized]public LampRelight relight;
    [NonSerialized] public LampColorGradient gradient;

    public float currentLightValue;
    public float dimSpeed;
    public float maxLightIntensity;

    private float rangeDimFactor;

    private void Awake()
    {
        relight = GetComponent<LampRelight>().InjectLamp(this);
        gradient = GetComponent<LampColorGradient>();

        rangeDimFactor = maxLightIntensity / lightToFade.range;
    }

    void Update()
    {
        DimLightFixed();
        SetLightIntensity();
    }

    private void DimLightFixed()
    {
        currentLightValue -=
            dimSpeed * Time.deltaTime;

        currentLightValue = currentLightValue = Mathf.Clamp(currentLightValue,0, maxLightIntensity);
    }

    public void SetLightIntensity()
    {
        lightToFade.intensity = currentLightValue;
        lightToFade.range = currentLightValue / rangeDimFactor;
    }
    
    // private void DimLightLerped()
    // {
    //     var speedChanged = Math.Abs(currentLightValue - targetLightValue) >= 0.05f;
    //     if (speedChanged)
    //     {
    //         Mathf.Lerp(currentLightValue, targetLightValue, Time.deltaTime * dimSpeed);
    //         lightToFade.intensity = Mathf.Lerp(min, max, counter / duration);
    //     }
    //     else
    //     {
    //         currentLightValue = targetLightValue;
    //     }
    // }
}