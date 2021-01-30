using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    //moving on the ground
    public CharacterController controller;
    public Transform cam;
    private Animator animator;
    public float moveSpeed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //moving on the ground

    //jumping
    public static float verticalVelocity;
    public float gravity = 14.0f;
    public float jumpForce = 10.0f;

    public static bool grounded;

    //jumping

    public void setVerticalVel(float vel)
    {
        verticalVelocity = vel;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        handleJumping();

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

        }
    }

    private void handleJumping()
    {
        if (controller.isGrounded)
        {
            //animator.SetBool("IsInAir", false);

            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                //animator.SetBool("IsInAir", true);
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 jumnpVector = new Vector3(0f, verticalVelocity, 0f);
        controller.Move(jumnpVector * Time.deltaTime);
    }



}

 
