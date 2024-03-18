using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    Collider2D coll;
    SpriteRenderer mySpriteRenderer;
    Item item;
    SceneController controller;

    [Header("Inputs")]
    public Vector2 inputDirection;
    public bool jumpInput;
    public bool jumpHeld;
    public bool interactInput;
    public float jumpTimer;
    public float itemsCollected = 0;
   

    [Header("Modifiers")]
    [SerializeField] private float fallSpeedBuffer = 3f;
    [SerializeField] private float fallGravity = 3f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float groundVelocity = 5f;
    public float deccelerationMultiplier = 10f;
    [SerializeField] private float terminalVelocity = 10f;
    [SerializeField] private float minSpeed = 0.1f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private LayerMask itemLayers;

    [Header("Scene Controller")]
    [SerializeField] private float sceneTimer = 25;
    [SerializeField] private bool gameOver = false;

    private bool isGrounded;
    private bool canInteract;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        item = GetComponent<Item>();
    }

    // Update is called once per frame
    void Update() {
        jumpTimer -= Time.deltaTime;
        sceneTimer -= Time.deltaTime;

        if (jumpInput) {
            if (isGrounded) {
                Jump();
            }
        }

        if (sceneTimer < 0 && !gameOver) {
            gameOver = true;
            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame();

        }
    }

    private void FixedUpdate() {
        CheckWhatIsNear();
        ApplyMovement();
        ApplyGravity();
        ApplyDirection();
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

    private void ApplyDirection() {
        if (inputDirection.x != 0) {
            Vector3 currentScale = transform.localScale;
            transform.localScale = currentScale;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        Item item = collision.collider.GetComponent<Item>();

        if (item != null) {
            itemsCollected++;
            item.TakeHit();

        }
    }
}

