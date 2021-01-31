using TMPro;
using UnityEngine;

public class PartNumberUpdater : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text ="x " + GameManager.Instance.scoreHandler.NumberOfPickedUp;
    }
}