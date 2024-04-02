using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int value;

    // Start is called before the first frame update
    void Start() {

    }

    //When called it will destroy the gameobject and spawn a VFX
    public void TakeHit() {
        Destroy(gameObject);
    }

    public int GetValue()
    {
        return value;
    }
}

