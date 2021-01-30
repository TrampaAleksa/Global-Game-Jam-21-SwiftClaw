using UnityEngine;

public class SafeZoneArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.lightHandler.EnterSafeZone();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.lightHandler.ExitSafeZone();
        }
    }
}