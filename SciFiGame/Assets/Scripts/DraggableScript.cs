using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableScript : MonoBehaviour
{
    public float speedAdjustment = 1;
    private bool dragging = false;
    private Vector3 offset;
    private Rigidbody2D myRB2D;
    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown(){
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp(){
        //Lets you toss things around
        Vector2 vel = myRB2D.velocity;
        vel.x = Input.GetAxis("Mouse X") * speedAdjustment;
        vel.y = Input.GetAxis("Mouse Y") * speedAdjustment;
        myRB2D.velocity = vel;

        dragging = false;
    }
}
