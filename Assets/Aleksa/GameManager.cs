using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ScoreHandler scoreHandler;
    public LightHandler lightHandler;

    private void Awake()
    {
        Instance = this;
    }
    
    
}