using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //moving on the ground
    public CharacterController controller;
    public Transform cam;
    private Animator animator;
    public float moveSpeed = 3f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //moving on the ground

    //jumping
    public float verticalVelocity;
    public float gravity = 14.0f;
    public float jumpForce = 10.0f;

    //jumping

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

        if (direction.magnitude >= 0.1f) //length(player-distance)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

        }

        handleAnimations();
        //print("startFallPos Height "+ startFallPos.y);
       // print("Players current height "+ GetComponent<Transform>().position.y);
    }
    
    private void handleJumping()
    {
        if (controller.isGrounded)
        {
            animator.SetBool("IsInAir", false);
            
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {             
                animator.SetBool("IsInAir", true);
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

    public void handleAnimations()
    {
        handleWalkingAnim();
        handleRunningAnim();
    }

    private void handleRunningAnim()
    {
        if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")))
        {
            animator.SetBool("isRunning", true);
            moveSpeed = 6f;
        }
        else
        {
            animator.SetBool("isRunning", false);
            moveSpeed = 3f;
        }
    }

    private void handleWalkingAnim()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false); //handle idle
            moveSpeed = 3f;
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true); //handle idle
            moveSpeed = 3f;
        }
    }



}
