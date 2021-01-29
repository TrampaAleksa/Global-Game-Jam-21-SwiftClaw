using UnityEngine;

public class NearBoatPartZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.lightHandler.lamp.gradient.LampIsNear();
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