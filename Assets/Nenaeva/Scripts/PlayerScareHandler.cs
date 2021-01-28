using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScareHandler : MonoBehaviour
{
    [NonSerialized]public PlayerAiController aiController;

    public GameObject rtpObject;

    private void Awake()
    {
        aiController = FindObjectOfType<PlayerAiController>();
        
    }

    private ScareField currentField;
    public void RunToPoint(Transform runToPoint, ScareField field)
    {
        print("Player is scared, running!");
        aiController.SetTarget(runToPoint);
        runToPoint.GetComponentInChildren<RunToPoint>().EnablePoint();
        currentField = field;
    }

    public void StopsScare()
    {
        aiController.DisableAi();
        currentField.fieldSource.SetFieldState(ScareFieldState.Active);
    }
}