using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CrateCatchingPlayerController : PlayerBase
{

    [SerializeField] private float velocity = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        anim.SetInputs(new(inputDirection.x, 0), new(lastInputDirection.x, 0));

        rb.velocity = inputDirection.x * velocity * Vector2.right;
    }
}
