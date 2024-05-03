using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformingPlayerController : PlayerBase
{
    Collider2D coll;
    SpriteRenderer mySpriteRenderer;
    Scrap scrap;
    MinigameController controller;
    Rigidbody2D rb;
    public AudioSource powerUp;


    [Header("Inputs")]
    public float jumpTimer;
    public float itemsCollected = 0;
   
    [Header("Modifiers")]
    [SerializeField] private float fallSpeedBuffer = 3f;
    [SerializeField] private float fallGravity = 3f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float groundVelocity = 5f;
    [SerializeField] private float deccelerationMultiplier = 10f;
    [SerializeField] private float terminalVelocity = 10f;
    [SerializeField] private float minSpeed = 0.1f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private LayerMask itemLayers;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start() {
        coll = GetComponent<Collider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        scrap = GetComponent<Scrap>();
        controller = FindFirstObjectByType<MinigameController>();
        rb = GetComponent<Rigidbody2D>();

        InitializeComponents();
    }

    // Update is called once per frame
    void Update() {

        GetInputs();

        anim.SetInputs(new(inputDirection.x, 0), new(lastInputDirection.x, 0));

        if (jumpInput) {
            if (isGrounded) {
                Jump();
            }
        }
    }

    private void FixedUpdate() {
        CheckWhatIsNear();
        ApplyMovement();
        ApplyGravity();
    }

    private void ApplyMovement() {

        if (inputDirection.x != 0) {
            rb.velocity = new Vector2(inputDirection.x * groundVelocity, rb.velocity.y);
        } else {
            rb.AddForce(new Vector2(-rb.velocity.x * deccelerationMultiplier * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(rb.velocity.magnitude) < minSpeed) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void ApplyGravity() {
        if (rb.velocity.y < fallSpeedBuffer || !jumpHeld) {
            rb.AddForce(Vector2.up * Physics2D.gravity.y * (fallGravity - 1) * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (rb.velocity.y < -terminalVelocity) {
            rb.velocity = new Vector2(rb.velocity.x, -terminalVelocity);
        }
    }

    private void Jump() {
        jumpInput = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void CheckWhatIsNear() {
        Vector2 groundBoxPos = new Vector2(transform.position.x, transform.position.y - 0.2f);
        RaycastHit2D groundHit = Physics2D.BoxCast(groundBoxPos, coll.bounds.size, 0f, Vector2.down, .1f, groundLayers);
        RaycastHit2D itemHit = Physics2D.BoxCast(groundBoxPos, coll.bounds.size, 0f, Vector2.down, .1f, itemLayers);

        isGrounded = groundHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scrap = collision.collider.gameObject.GetComponent<Scrap>();

        if (scrap != null)
        {
            powerUp.Play();
            controller.IncreaseScore(scrap.GetValue());
            scrap.TakeHit();
        }
    }


}

