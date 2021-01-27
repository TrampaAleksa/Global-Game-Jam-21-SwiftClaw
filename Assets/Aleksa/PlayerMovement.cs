using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float movementSpeed;
    public float rotationSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        var playerTransform = transform;

        var vAxis = Input.GetAxis("Vertical");
        if (vAxis != 0)
        {
            rb.MovePosition(playerTransform.position + playerTransform.forward * (vAxis * movementSpeed * Time.fixedDeltaTime));
        }

        var hAxis = Input.GetAxis("Horizontal");
        if (hAxis != 0)
        {
            playerTransform.Rotate(0, rotationSpeed * hAxis * Time.fixedDeltaTime, 0);
        }
    }
}