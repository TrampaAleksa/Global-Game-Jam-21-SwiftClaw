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
        text.text = GameManager.Instance.scoreHandler.NumberOfPickedUp.ToString();
    }
}