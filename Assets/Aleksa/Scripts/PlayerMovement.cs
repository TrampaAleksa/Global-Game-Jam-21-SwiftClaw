using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float movementSpeed;
    public float rotationSpeed;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Transform cam;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            GameManager.Instance.playerAnimator.SetBool(IsWalking, true);
            return;
        }
        
        GameManager.Instance.playerAnimator.SetBool(IsWalking, false);

    }

    private void FixedUpdate()
    {
        var playerTransform = transform;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.MovePosition(playerTransform.position + moveDir.normalized * (movementSpeed * Time.deltaTime));
            
        }
    }
}