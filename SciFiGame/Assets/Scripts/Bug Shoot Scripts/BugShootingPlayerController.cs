using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugShootingPlayerController : PlayerBase
{
    Rigidbody2D rb;

    [SerializeField] private int velocity = 5;
    [SerializeField] private float rateOfFire = 1;
    public Vector3 inputDirect;

    public GameObject laser;
    public AudioClip laserSound;
    public Animator animator;

    private float lastTimeFired = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        if (interactInput && (lastTimeFired + 1 / rateOfFire) < Time.time) {
            lastTimeFired = Time.time;
            FireTheLasers();
        }

        rb.velocity = inputDirection.normalized * velocity;
        anim.SetInputs(inputDirection, lastInputDirection);
    }

    void FireTheLasers(){
        Quaternion rot = Quaternion.identity;

        AnimatorClipInfo[] animInfo = this.animator.GetCurrentAnimatorClipInfo(0);

        AudioSource.PlayClipAtPoint(laserSound, transform.position);
        // Shooting up
        inputDirect = new Vector3(lastInputDirection.x, lastInputDirection.y, 0);

        if (animInfo[0].clip.name == "walking-front" || animInfo[0].clip.name == "walking-back" || animInfo[0].clip.name == "idle-front" || animInfo[0].clip.name == "idle-back") {

            rot = Quaternion.Euler(0, 0, 90);
        }

        Instantiate(laser, transform.position + new Vector3(lastInputDirection.x, lastInputDirection.y, 0), rot);

    }
}
