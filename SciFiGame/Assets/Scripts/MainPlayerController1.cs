using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController3D : PlayerBase
{
    Rigidbody rb;

    [SerializeField] private GameObject interactSign;
    [SerializeField] private int velocity = 5;

    private bool canInteract;
    private Interactable interactable;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InitializeComponents();
    }

    // Update is called once per frame
    void Update()
    {

        GetInputs();

        rb.velocity = new Vector3(inputDirection.x, 0, inputDirection.y).normalized * velocity;

        if (canInteract && interactInput)
        {
            interactable.Interact(gameObject);
        }

        interactSign.SetActive(canInteract);

        anim.SetInputs(inputDirection, lastInputDirection);
    }

    private void OnTriggerStay(Collider collision)
    {
        interactable = collision.gameObject.GetComponent<Interactable>();
        canInteract = interactable != null;
    }

    private void OnTriggerExit(Collider collision)
    {
        interactable = null;
        canInteract = false;
    }
}
