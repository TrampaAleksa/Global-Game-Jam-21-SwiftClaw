using UnityEngine;

public class LightHandler : MonoBehaviour
{
    public Lamp lamp;
    public void AddLight(int value)
    {
        lamp.currentLightValue += value;
        print("Adding light : " + value);
    }
}