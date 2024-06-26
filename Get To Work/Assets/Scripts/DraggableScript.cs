using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableScript : MonoBehaviour
{
    public float speedAdjustment = 1;
    public float newScaleX;
    public float newScaleY;
    public bool dragging = false;

    private Vector3 oldScale;
    private Vector3 offset;
    private Rigidbody2D myRB2D;

    //for sound effect playing
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myRB2D = GetComponent<Rigidbody2D>();
        oldScale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dragging){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

        if (SceneController.Instance.IsPaused())
        {
            dragging = false;
        }
    }

    private void OnMouseDown(){
        if (!SceneController.Instance.IsPaused())
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localScale = new Vector3(newScaleX, newScaleY, 1);
            audioSource.Play();
            dragging = true;
        }
    }

    private void OnMouseUp(){
        //Lets you toss things around
        Vector2 vel = myRB2D.velocity;
        vel.x = Input.GetAxis("Mouse X") * speedAdjustment;
        vel.y = Input.GetAxis("Mouse Y") * speedAdjustment;
        myRB2D.velocity = vel;

        transform.localScale = oldScale;

        dragging = false;
    }
}
