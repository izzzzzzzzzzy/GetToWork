using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    MinigameController controller;
    Collider2D coll;
    Rigidbody2D rb;

    [SerializeField] private int value;

    private bool broken;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<MinigameController>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!broken && collider.CompareTag("Crate Stack"))
        {
            transform.SetParent(collider.transform.parent);
            controller.IncreaseScore(value);
            Destroy(rb);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            controller.DecreaseScore(value);
            Destroy(gameObject);
        }
    }
}
