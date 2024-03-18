using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour {
    public Vector2 inputDirection;
    Animator animator;
    public bool jumpHeld;
    public bool jumpInput;
    public bool breathInput;
    public bool glideInput;
    public bool interactInput;

    PlayerMovement movement;
    // Start is called before the first frame update
    void Start() {
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        jumpHeld = Input.GetButton("Jump");
        jumpInput = Input.GetButtonDown("Jump");
        breathInput = Input.GetKeyDown(KeyCode.F);
        glideInput = Input.GetKey(KeyCode.LeftShift);
        interactInput = Input.GetKeyDown(KeyCode.E);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            //TODO: Pause game
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (movement != null) {
            movement.inputDirection = inputDirection;
            movement.jumpHeld = jumpHeld;
            movement.jumpInput = jumpInput;
            movement.interactInput = interactInput;


            // Animation logic
            animator.SetFloat("walkingSpeed", inputDirection.x);

        }
    }
}

