using UnityEngine;

public class LampColorGradient : MonoBehaviour
{
    public float gradientSpeed;
    private Color regularColor;

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
        regularColor = new Color(color.r, color.g , color.b, color.a);
    }

    public void LampIsNear(Color colorChange)
    {
        timedAction.CancelTimer();
        targetColor = new Color(colorChange.r, colorChange.g, colorChange.b, colorChange.a);
        counter = 0f;
        
        var color = lightHandler.lamp.lightToFade.color;
        colorOnStart = new Color(color.r, color.g , color.b, color.a);
        
        timedAction.StartTimedAction(() => print("near ship part"), gradientSpeed);
    }

    public void LampIsFar()
    {
        timedAction.CancelTimer();
        targetColor = new Color(regularColor.r, regularColor.g, regularColor.b, regularColor.a);;
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