using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;

    [SerializeField] private int health = 1;
    [SerializeField] private float velocity = 3.0f;
    [SerializeField] private float sightRange = 1f;
    [SerializeField] private LayerMask wallLayers;
    MinigameController controller;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = rb.GetComponent<Collider2D>();
        controller = FindFirstObjectByType<MinigameController>();
    }

    private void Update() {
        print(rb.velocity);

        if (rb.velocity.magnitude < 0.1) {
            int turnDistance = Random.Range(1, 4) * 90;

            transform.Rotate(new(0, 0, turnDistance));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            rb.velocity = velocity * transform.up;

        }
    }

    private bool CheckForWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, sightRange, wallLayers);

        return hit.collider != null;
    }

    public void TakeHit(int damage){
        health -= damage;

        if (health <= 0)
        {
            isDead = true;
            controller.IncreaseScore(3);
            Destroy(gameObject);
        }
    }
}
