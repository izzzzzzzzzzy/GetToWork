using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BugController : MonoBehaviour
{
    [SerializeField] private int health = 2;
    [SerializeField] private float speed;
    [SerializeField] private Sprite deadBug;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(health <= 0){
            spriteRenderer.sprite = deadBug;
            Destroy(gameObject, .5f);
        } else
        {
            //rb.velocity = GetMoveDirection() * speed;
        }
    }

    public void TakeHit(int damage){
        health -= damage;
    }

    private void GetMoveDirection()
    {
        
    }
}
