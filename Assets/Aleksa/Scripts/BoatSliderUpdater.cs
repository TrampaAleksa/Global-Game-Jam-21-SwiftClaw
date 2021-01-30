using UnityEngine;
using UnityEngine.UI;

public class BoatSliderUpdater : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = GameManager.Instance.scoreHandler.scoreForWin;
    }

    private void Update()
    {
        slider.value = GameManager.Instance.scoreHandler.TotalPartsDelivered;
    }
}