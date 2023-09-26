using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public Rigidbody rb;
    public float mvSpeed = 3.0f;
    public CharacterController charControl;
    private PlayerInput playerInput;

    private bool charIsGrounded;
    private float noSlipDistance = 0.1f;

    //movement
    private bool isMovementPressed;
    private Vector2 moveDirection = Vector2.zero;
    private Vector3 currentMovment;

    //animation
    private Animator animator;
    float rotationFactorPerFrame = 50.0f;
    int isJumpingHash;
    bool isJumpAnimating = false;

    //gravity
    float gravity = -10f;
    float groundedGravity = -.05f;

    //jumping
    private bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 3.0f;
    float maxJumpTime = 0.75f;
    bool isJumping = false;

    void Awake()
    {
        playerInput = new PlayerInput();
        animator = GetComponent<Animator>();

        isJumpingHash = Animator.StringToHash("isJumping");

        playerInput.Player.Move.started += onMovementInput;
        playerInput.Player.Move.canceled += onMovementInput;
        playerInput.Player.Move.performed += onMovementInput;
        playerInput.Player.Jump.started += onJump;
        playerInput.Player.Jump.canceled += onJump;

        setupJumpVaria();

    }

    // hiting ceiling
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null)
        {
            if (body.gameObject.tag == "Ceiling")
            {
                currentMovment.y = 0;
            }
        }
    }
    void onMovementInput(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        currentMovment.x = moveDirection.x * mvSpeed;
        //currentMovment.z = moveDirection.y;
        isMovementPressed = moveDirection.x != 0; //|| moveDirection.y != 0;
    }
    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }


    private void FixedUpdate()
    {
        if (charControl)
        {
            handleRotation();
            handleAnimation();
            charControl.Move(currentMovment * Time.deltaTime);
            handleGravity();
            handleJump();
        }

        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position + charControl.center, 
            charControl.radius - charControl.skinWidth, 
            Vector3.down, out hitInfo, 
            charControl.height))
        {
            Vector3 relativeHitPoint = hitInfo.point - (transform.position + charControl.center);
            float hitHeight = relativeHitPoint.y;
            relativeHitPoint.y = 0;
            relativeHitPoint.z = 0;
            if (relativeHitPoint.magnitude > noSlipDistance)
            {
                charControl.Move(-relativeHitPoint * Time.deltaTime * 3);
            }
        }
    }
    void handleGravity()
    {
        bool isFalling = currentMovment.y <= 0.0f || !isJumpPressed;
        float fallMultiplier = 2.0f;
        if (charControl.isGrounded)
        {
            if (isJumpAnimating)
            {
                animator.SetBool(isJumpingHash, false);
                isJumpAnimating = false;
            }
            currentMovment.y = groundedGravity;
        }else if(isFalling)
        {
            float previousYVelocity = currentMovment.y;
            float newYVelocity = currentMovment.y + (gravity * fallMultiplier * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            currentMovment.y = nextYVelocity;
        } 
        else
        {
            float previousYVelocity = currentMovment.y;
            float newYVelocity = currentMovment.y + (gravity * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            currentMovment.y = nextYVelocity;
        }
    }
    void handleJump()
    {
        if (!isJumping && charControl.isGrounded && isJumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
            isJumpAnimating = true;
            isJumping = true;
            currentMovment.y = initialJumpVelocity * .5f; 
        } else if (!isJumpPressed && isJumping && charControl.isGrounded)
        {
            isJumping = false;
        }
    }
    void handleAnimation()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");

        if (isMovementPressed && !isRunning)
        {
            animator.SetBool("isRunning", true);
        } else if (!isMovementPressed && isRunning)
        {
            animator.SetBool("isRunning", false);
        }
        
    }
    void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovment.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovment.z;
        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, 
                targetRotation, 
                rotationFactorPerFrame);
        }
    }
    void setupJumpVaria()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }
    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
