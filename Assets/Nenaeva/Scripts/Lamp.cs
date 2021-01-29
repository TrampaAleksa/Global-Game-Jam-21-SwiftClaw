using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light lightToFade;

    public float currentLightValue;
    public float dimSpeed;
    public float maxLightIntensity;
    public float relitTime = 1f;

    private TimedAction timedAction;

    private void Awake()
    {
        timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        timedAction.AddTickAction(RelitLightLerped);
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
    
    public void Relight()
    {
        counter = 0f;
        lightAtRelitStart = currentLightValue;
        timedAction.StartTimedAction(() => print("Light relit"), relitTime);
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

    private float counter;
    private float lightAtRelitStart;
    
    private void RelitLightLerped()
    {
        counter += Time.deltaTime;
            currentLightValue = Mathf.Lerp(lightAtRelitStart, maxLightIntensity, counter/ relitTime);
            lightToFade.intensity = currentLightValue;
    }
}

public class LampRelight : MonoBehaviour
{
    public float relightTime = 1f;
    
    private float counter;
    private float lightAtRelightStart;

    private Lamp lamp;
    private TimedAction timedAction;

    private void Awake()
    {
        timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        timedAction.AddTickAction(RelightLightLerped);
    }

    private void InjectLamp(Lamp lamp) => this.lamp = lamp;

    private void RelightLightLerped()
    {
        counter += Time.deltaTime;
        lamp.currentLightValue = Mathf.Lerp(lightAtRelightStart, lamp.maxLightIntensity, counter/ relightTime);
        lamp.lightToFade.intensity = lamp.currentLightValue;
    }
}