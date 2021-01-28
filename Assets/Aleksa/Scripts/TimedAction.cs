using System;
using UnityEngine;

public class TimedAction : MonoBehaviour
{
    private Action timerFinishedAction;
    private Action tickAction;

    private float timeSinceStart;
    private float finishTime;
    private bool timerStarted;

    private bool destroyOnFinish = true;

    public void StartTimedAction(Action timerFinishAction, float timerDuration)
    {
        timerFinishedAction = timerFinishAction;
   
        timeSinceStart = Time.time;
        finishTime = timerDuration + timeSinceStart;

        timerStarted = true;
    }

    private float remainingTime;

    public void PauseTimer()
    {
        if (!timerStarted) return;
      
        timerStarted = false;
        remainingTime = finishTime - timeSinceStart;
    }

    public void UnpauseTimer()
    {
        if (timerStarted) return;
      
        timeSinceStart = Time.deltaTime;
        finishTime = remainingTime + timeSinceStart;
        timerStarted = true;
    }
    public void CancelTimer() => timerStarted = false;

    private void Update()
    {
        if (timerStarted)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timeSinceStart += Time.deltaTime;
        if (TimerFinished())
        {
            timerStarted = false;
            timerFinishedAction?.Invoke();
            if (destroyOnFinish) Destroy(this);
        }
        else
        {
            tickAction?.Invoke();
        }
    }

    public void AddTickAction(Action toAdd) => tickAction = toAdd;

    public TimedAction DestroyOnFinish(bool value) {
        destroyOnFinish = value;
        return this;
    }

    private bool TimerFinished() => timeSinceStart >= finishTime;
   
}