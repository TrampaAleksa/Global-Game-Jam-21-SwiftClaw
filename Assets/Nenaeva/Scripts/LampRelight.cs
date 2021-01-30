using UnityEngine;

public class LampRelight : MonoBehaviour
{
    public float relightTime = 1f;
    
    private float counter;
    private float lightAtStart;

    private Lamp lamp;
    private TimedAction timedAction;

    private void Awake()
    {
        timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        timedAction.AddTickAction(RelightLightLerped);
    }

    public LampRelight InjectLamp(Lamp lamp)
    {
        this.lamp = lamp;
        return this;
    }

    private void RelightLightLerped()
    {
        counter += Time.deltaTime;
        lamp.currentLightValue = Mathf.Lerp(lightAtStart, lamp.maxLightIntensity, counter/ relightTime);
        lamp.SetLightIntensity();
    }

    public void Trigger()
    {
        counter = 0f;
        lightAtStart = lamp.currentLightValue;
        
        timedAction.StartTimedAction(() => print("FinishedRelighting"), relightTime);
    }
    public void Cancel() => timedAction.CancelTimer();

}