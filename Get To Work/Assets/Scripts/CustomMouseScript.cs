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
        transform.position = Input.mousePosition;
        lastMousePos = Input.mousePosition;
    }

}
