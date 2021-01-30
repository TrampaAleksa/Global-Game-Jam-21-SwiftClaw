using UnityEngine;
using UnityEngine.UI;

public class LightSliderUpdater : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = GameManager.Instance.lightHandler.lamp.maxLightIntensity;
    }

    private void Update()
    {
        slider.value = GameManager.Instance.lightHandler.lamp.currentLightValue;
    }
}