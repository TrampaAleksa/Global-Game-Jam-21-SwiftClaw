using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScareHandler : MonoBehaviour
{
    public PlayerAiController aiController;
    
    public void RunToPoint(Transform runToPoint, ScareField field)
    {
        print("Player is scared, running!");

        StartCoroutine(Delay(field));
    }

    IEnumerator Delay(ScareField field)
    {
        yield return  new WaitForSeconds(5f);
        
        field.fieldSource.SetFieldState(ScareFieldState.Active);
    }
}