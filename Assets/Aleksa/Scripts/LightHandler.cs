﻿using System;
using UnityEngine;

public class LightHandler : MonoBehaviour
{
    [NonSerialized] public Lamp lamp;
    public float fireflyCooldown;

    private void Awake()
    {
        lamp = FindObjectOfType<Lamp>();
    }
    public void AddLight(int value)
    {
        lamp.currentLightValue += value;
        print("Adding light : " + value);
    }


    private void Update()
    {
        if (lamp.currentLightValue > 0) return;
        
        InGameScreen igs = (InGameScreen) UIController.Instance.currentScreen;
        igs.ChangeSubScreen((int)InGameScreen.SubScreenState.tryAgain);
        
        // Game Over    
        // print("Game Over");
    }

    public void EnterSafeZone()
    {
        lamp.relight.Trigger();
        lamp.enabled = false;
    }
    
    public void ExitSafeZone()
    {
        lamp.enabled = true;
        lamp.relight.Cancel();
    }
}