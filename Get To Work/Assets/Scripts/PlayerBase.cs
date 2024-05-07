using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected PlayerAnimator anim;
    protected InputHandler inputs;
    protected Vector2 inputDirection;
    protected Vector2 lastInputDirection;
    protected bool jumpInput;
    protected bool jumpHeld;
    protected bool interactInput;
    protected static bool canWalk = true;
    protected static bool canInteract = true;

    protected void InitializeComponents()
    {
        anim = GetComponent<PlayerAnimator>();
        inputs = GetComponent<InputHandler>();
    }

    protected void GetInputs()
    {
        if (!SceneController.Instance.IsPaused())
        {
            interactInput = inputs.GetInteractInput();
        }
        else
        {
            interactInput = false;
        }

        if (canWalk)
        {
            inputDirection = inputs.GetDirection();
            jumpInput = inputs.GetJumpInput();
            jumpHeld = inputs.GetJumpHeld();
        }
        else
        {
            inputDirection = Vector2.zero;
            jumpInput = false;
            jumpHeld = false;
        }

        if (inputDirection.magnitude != 0)
        {
            lastInputDirection = inputDirection;
        }
    }

    public static void SetCanWalk(bool canWalk)
    {
        PlayerBase.canWalk = canWalk;
    }

    public static void SetCanInteract(bool canInteract)
    {
        PlayerBase.canInteract = canInteract;
    }
}