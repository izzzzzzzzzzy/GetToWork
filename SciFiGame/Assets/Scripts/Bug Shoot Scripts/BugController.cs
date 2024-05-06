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
    [SerializeField] private float knockbackDistance = 2.0f;
    [SerializeField] private float stunDuration = 1.0f;

    private bool isDead;
    private float stunTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = rb.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (stunTimer > 0)
            {
                rb.velocity = velocity * transform.right;
            }

            if (CheckForWall())
            {
                int turnDistance = Random.Range(1, 4) * 90;

                transform.Rotate(new(0, 0, turnDistance));
            }
        }
        stunTimer -= Time.deltaTime;
    }

    private bool CheckForWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, sightRange, wallLayers);

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
