using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMouseScript : MonoBehaviour
{
    private Vector3 lastMousePos;
    public Vector3 mouseDelta
    {
	   get
	   {
		return Input.mousePosition - lastMousePos;
	   }
    }
    //Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        lastMousePos = Input.mousePosition;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.position * 1 * Time.deltaTime;
        //transform.position = new Vector3 (mouseDelta.x, mouseDelta.y, Quaternion.identity) * Time.deltaTime;
        //transform.position = new Vector3(
        //    Mathf.Clamp(transform.position.x, 0f, Screen.width),
        //    Mathf.Clamp(transform.position.y, 0f, Screen.height),
        //    0f);
        //transform.position.x = Input.GetAxis("Mouse x") * Time.deltaTime;
        //transform.position.y = Input.GetAxis("Mouse y") * Time.deltaTime;
        transform.position = Input.mousePosition;
        lastMousePos = Input.mousePosition;
    }

}
