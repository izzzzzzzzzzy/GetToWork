using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : PlayerBase
{
    //SceneController controller;
    Rigidbody2D rb;

    [SerializeField] private GameObject interactSign;
    [SerializeField] private int velocity = 5;

    private bool canInteract;
    private Interactable interactable;


    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        if (canInteract && interactInput)
        {
            interactable.Interact(gameObject);
        }

        interactSign.SetActive(canInteract);

        //int legHealth = MainManager.Instance.rLegHealth + MainManager.Instance.lLegHealth;
        rb.velocity = inputDirection.normalized * velocity; //* (legHealth/200);
        anim.SetInputs(inputDirection, lastInputDirection);
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
}
