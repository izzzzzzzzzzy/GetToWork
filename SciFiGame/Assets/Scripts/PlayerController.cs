using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private GameObject interactSign;
    [SerializeField] private Vector2 inputDirection;
    [SerializeField] private int velocity = 5;

    private bool canInteract;
    private IInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = inputDirection.normalized * velocity;

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactable.interact(gameObject);
        }

        interactSign.SetActive(canInteract);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactable = collision.gameObject.GetComponent<IInteractable>();
        canInteract = interactable != null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
        canInteract = false;
    }
}
