﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light lightToFade;
    public LampRelight relight;

    public float currentLightValue;
    public float dimSpeed;
    public float maxLightIntensity;

    private void Awake()
    {
        relight = GetComponent<LampRelight>().InjectLamp(this);
    }

    void Update()
    {
        DimLightFixed();
        lightToFade.intensity = currentLightValue;
    }

    private void DimLightFixed()
    {
        currentLightValue -=
            dimSpeed * Time.deltaTime;

        currentLightValue = currentLightValue = Mathf.Clamp(currentLightValue,0, maxLightIntensity);
    }
    public void Relight() => relight.Trigger();

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