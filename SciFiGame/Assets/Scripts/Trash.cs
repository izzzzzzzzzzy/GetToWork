using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody rb;

    [SerializeField] private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow };

    private int color;
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();

        color = Mathf.FloorToInt(Random.Range(0, colors.Length));

        spriteRenderer.color = colors[color];
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.position + (Vector3.up * speed);


        if (transform.position.y > 7.5)
        {
            transform.position = new Vector2(transform.position.x, -7.5f);
        }
    }

    public void SetSpeed(int nSpeed)
    {
        speed = nSpeed;
    }
}
