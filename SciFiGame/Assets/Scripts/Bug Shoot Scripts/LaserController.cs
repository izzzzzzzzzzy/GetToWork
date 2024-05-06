using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 5;
    public float lifeTime = 3;

    private Vector2 direction;
    private GameObject player;
    public Rigidbody2D rb;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        direction = player.GetComponent<BugShooterPlayerController>().inputDirect;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(direction.x, direction.y,0) * speed;
		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0){
			Destroy(gameObject);
		}
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.CompareTag("Bug")){
            BugController bug = col.gameObject.GetComponent<BugController>();
            bug.TakeHit(2);
            Destroy(gameObject);
        }
    }
}
