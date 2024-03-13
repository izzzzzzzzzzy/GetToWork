using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;

    [SerializeField] private GameObject interactSign;
    [SerializeField] private Vector2 inputDirection;
    [SerializeField] private int velocity = 5;

    private bool canInteract;
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = inputDirection.normalized * velocity;

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact(gameObject);
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
        anim.SetBool("isWalking", inputDirection.magnitude != 0);
    }
}
