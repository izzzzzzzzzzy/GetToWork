using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    //When called it will destroy the gameobject and spawn a VFX
    public void TakeHit() {
        Destroy(gameObject);
    }
}

