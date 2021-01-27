using System;
using UnityEngine;
using UnityEngine.Events;

public class PickupItem : MonoBehaviour
{
    public UnityEvent pickupEvent;

    protected virtual void TriggeredPickup()
    {
        pickupEvent?.Invoke();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggeredPickup();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TriggeredPickup();
        }
    }
}