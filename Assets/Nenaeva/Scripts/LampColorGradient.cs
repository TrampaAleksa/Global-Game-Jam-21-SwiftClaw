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
        timedAction = gameObject.AddComponent<TimedAction>();
        timedAction.AddTickAction(GradualColorChange);
    }

    private void Start()
    {
        lightHandler = GameManager.Instance.lightHandler;
        farColor = lightHandler.lamp.lightToFade.color;
        targetColor = nearColor;
    }

    public void LampIsNear()
    {
        targetColor = nearColor;
        counter = 0f;
        timedAction.StartTimedAction(() => print("near ship part"), gradientSpeed);
    }

    public void LampIsFar()
    {
        targetColor = farColor;
        counter = 0f;
        timedAction.StartTimedAction(() => print("far from ship part"), gradientSpeed);
    }

    private float counter;
    private void GradualColorChange()
    {
        counter += Time.deltaTime;
        lightHandler.lamp.lightToFade.color = Color.Lerp(lightHandler.lamp.lightToFade.color, targetColor, counter/ gradientSpeed);
    }
}