using UnityEngine;

public class ShipDropdownArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.scoreHandler.DeliverParts();
        }
    }
}