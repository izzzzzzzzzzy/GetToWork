using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SceneController controller;

    [SerializeField] private GameObject interactSign;
    [SerializeField] private Vector2 inputDirection;

    [SerializeField] private int velocity = 5;

    private bool canInteract;
    private Interactable interactable;
    private bool isPaused;

    // Animator stuff
    public Animator anim;
    private Vector2 lastInputDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controller = FindFirstObjectByType<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = controller.getPaused();

        if (!isPaused)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if ((moveX == 0 && moveY == 0) && (inputDirection.x != 0 || inputDirection.y != 0))
            {
                lastInputDirection = inputDirection;
            }

            inputDirection = new Vector2(moveX, moveY);

            rb.velocity = inputDirection.normalized * velocity;

            if (canInteract && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(gameObject);
            }
        }

        interactSign.SetActive(canInteract);
        Animate();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactable = collision.gameObject.GetComponent<Interactable>();
        canInteract = interactable != null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
        canInteract = false;
    }

    private void Animate() {
        anim.SetFloat("AnimMoveX", inputDirection.x);
        anim.SetFloat("AnimMoveY", inputDirection.y);
        anim.SetFloat("AnimLastMoveX", lastInputDirection.x);
        anim.SetFloat("AnimLastMoveY", lastInputDirection.y);
        anim.SetBool("isWalking", inputDirection.magnitude != 0);
    }
}
