using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScareHandler : MonoBehaviour
{
    [NonSerialized]public PlayerAiController aiController;

    public float jumpScareDuration;
    
    private void Awake()
    {
        aiController = FindObjectOfType<PlayerAiController>();
    }

    private ScareField currentField;
    public void RunToPoint(Transform runToPoint, ScareField field)
    {
        StartCoroutine(JumpscareDelay(runToPoint, field));
    }

    private IEnumerator JumpscareDelay(Transform runToPoint, ScareField field)
    {
        GameManager.Instance.playerAnimator.SetTrigger("JumpScare");
        
        yield return new WaitForSeconds(jumpScareDuration);
        
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