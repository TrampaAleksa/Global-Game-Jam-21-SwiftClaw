using UnityEngine;

public class GradientChangeZone : MonoBehaviour
{
    public Color colorToSet;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.lightHandler.lamp.gradient.LampIsNear(colorToSet);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.lightHandler.lamp.gradient.LampIsFar();
        }
    }
}