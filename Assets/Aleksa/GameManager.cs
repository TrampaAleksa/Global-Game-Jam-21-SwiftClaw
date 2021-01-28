using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [NonSerialized]public ScoreHandler scoreHandler;
    [NonSerialized]public LightHandler lightHandler;

    private void Awake()
    {
        Instance = this;

        scoreHandler = GetComponentInChildren<ScoreHandler>();
        lightHandler = GetComponentInChildren<LightHandler>();
    }
    
    
}