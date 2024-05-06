using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;

    [SerializeField] private int health = 2;
    [SerializeField] private float velocity = 3.0f;
    [SerializeField] private float sightRange = 1f;
    [SerializeField] private LayerMask wallLayers;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = rb.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            rb.velocity = velocity * transform.up;

            if (CheckForWall())
            {
                int turnDistance = Random.Range(1, 4) * 90;

                transform.Rotate(new(0, 0, turnDistance));
            }
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
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        coll.enabled = false;
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
