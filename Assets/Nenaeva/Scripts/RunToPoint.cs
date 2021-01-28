using UnityEngine;

public class RunToPoint : MonoBehaviour
{
    private BoxCollider collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
        DisablePoint();
    }

    public void EnablePoint()
    {
        collider.enabled = true;
    }

    private void DisablePoint()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.scareHandler.StopsScare();
            DisablePoint();
        }
    }
}