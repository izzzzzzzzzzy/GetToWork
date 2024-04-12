using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Vector2 inputDirection;
    private Vector2 lastInputDirection;

    SceneController controller;
    Animator anim;
    AudioSource footsteps;

    bool isMoving;
    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null) {
            controller = FindFirstObjectByType<SceneController>();
        }

        if (!controller.IsPaused())
        {

            anim.SetFloat("AnimMoveX", inputDirection.x);
            anim.SetFloat("AnimMoveY", inputDirection.y);
            anim.SetFloat("AnimLastMoveX", lastInputDirection.x);
            anim.SetFloat("AnimLastMoveY", lastInputDirection.y);

            anim.SetBool("isWalking", inputDirection != Vector2.zero);

            if ((inputDirection.x != 0 || inputDirection.y != 0) && !canJump) {
                isMoving = true;
            } else if (inputDirection.y == 0 && inputDirection.x != 0 && canJump) {
                isMoving = true;
            } else {
                isMoving = false;
            }

            if (isMoving && !footsteps.isPlaying) {
                footsteps.Play();
            }
            if (!isMoving) {
                footsteps.Stop();
            }
        }
    }

    public void SetInputs(Vector2 inputDirection, Vector2 lastInputDirection)
    {
        this.inputDirection = inputDirection;
        this.lastInputDirection = lastInputDirection;
    }
}
