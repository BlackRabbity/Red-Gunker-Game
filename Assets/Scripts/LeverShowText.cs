using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeverShowText : MonoBehaviour
{
    // text
    public GameObject text;
    private GameObject cloneText;

    //opening doors with button
    private bool doneOpening = false;
    private bool colliding = false;
    private bool isInteracting = false;
    private PlayerInput playerInput;

    //door
    public GameObject door;
    private Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = door.GetComponent<Animator>();
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Player.Interact.started += onInteract;
        playerInput.Player.Interact.canceled += onInteract;
    }

    private void onInteract(InputAction.CallbackContext context)
    {
        isInteracting = context.ReadValueAsButton();
    }

    private void Update()
    {
        if (colliding)
        {
            if (!doneOpening && isInteracting)
            {
                doneOpening = true;
                this.GetComponent<Animator>().Play("LeverAnimation");
                doorAnimator.Play("OpenDoorAnimation");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowTextOnLeverHit();
            colliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(cloneText);
            colliding = false;
        }
    }


    private void ShowTextOnLeverHit()
    {
        cloneText = Instantiate(text, transform.position, Quaternion.identity, transform);
    }
}
