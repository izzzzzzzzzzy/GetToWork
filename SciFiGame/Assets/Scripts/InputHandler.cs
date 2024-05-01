using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour {

    public Vector2 inputDirection;
    public bool jumpHeld;
    public bool jumpInput;
    public bool interactInput;
    public bool pauseInput;

    // Update is called once per frame
    void Update() {
        if (SceneController.inputsEnabled) {
            inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            jumpHeld = Input.GetButton("Jump");
            jumpInput = Input.GetButtonDown("Jump");
            interactInput = Input.GetKeyDown(KeyCode.E);
            pauseInput = Input.GetKeyDown(KeyCode.Escape);
        }
    }

    public Vector2 GetDirection()
    {
        return inputDirection;
    }

    public bool GetJumpHeld()
    {
        return jumpHeld;
    }

    public bool GetJumpInput() { 
        return jumpInput;
    }

    public bool GetInteractInput()
    {
        return interactInput;
    }

    public bool GetPauseInput() { 
        return pauseInput;
    }
}

