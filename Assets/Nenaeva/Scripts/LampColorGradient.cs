using UnityEngine;

public class LampColorGradient : MonoBehaviour
{
    public Color nearColor;
    public float gradientSpeed;
    private Color farColor;

    private Color targetColor;

    private LightHandler lightHandler;
    private TimedAction timedAction;

    private void Awake()
    {
        timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        timedAction.AddTickAction(GradualColorChange);
    }

    private void Start()
    {
        lightHandler = GameManager.Instance.lightHandler;
        
        var color = lightHandler.lamp.lightToFade.color;
        farColor = new Color(color.r, color.g , color.b, color.a);
        targetColor = new Color(nearColor.r, nearColor.g, nearColor.b, nearColor.a);
    }

    public void LampIsNear()
    {
        timedAction.CancelTimer();
        targetColor = new Color(nearColor.r, nearColor.g, nearColor.b, nearColor.a);
        counter = 0f;
        
        var color = lightHandler.lamp.lightToFade.color;
        colorOnStart = new Color(color.r, color.g , color.b, color.a);
        
        timedAction.StartTimedAction(() => print("near ship part"), gradientSpeed);
    }

    public void LampIsFar()
    {
        timedAction.CancelTimer();
        targetColor = new Color(farColor.r, farColor.g, farColor.b, farColor.a);;
        counter = 0f;
        
        var color = lightHandler.lamp.lightToFade.color;
        colorOnStart = new Color(color.r, color.g , color.b, color.a);
        timedAction.StartTimedAction(() => print("far from ship part"), gradientSpeed);
    }

    private float counter;
    private Color colorOnStart;
    private void GradualColorChange()
    {
        counter += Time.deltaTime;
        lightHandler.lamp.lightToFade.color = Color.Lerp(colorOnStart, targetColor, counter/ gradientSpeed);
    }
}