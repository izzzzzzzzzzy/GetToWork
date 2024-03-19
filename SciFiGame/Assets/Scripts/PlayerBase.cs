using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected PlayerAnimator anim;
    protected InputHandler inputs;
    protected Vector2 inputDirection;
    protected Vector2 lastInputDirection;
    protected bool jumpInput;
    protected bool jumpHeld;
    protected bool interactInput;

    protected void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimator>();
        inputs = GetComponent<InputHandler>();
    }

    protected void GetInputs()
    {
        jumpInput = inputs.GetJumpInput();
        jumpHeld = inputs.GetJumpHeld();
        interactInput = inputs.GetInteractInput();
        inputDirection = inputs.GetDirection();

        if (inputDirection.magnitude != 0)
        {
            lastInputDirection = inputDirection;
        }
    }
}
