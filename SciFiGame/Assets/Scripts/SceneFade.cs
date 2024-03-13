using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void FadeOut()
    {
        animator.SetBool("isFaded", true);
    }

    public void FadeIn()
    {
        animator.SetBool("isFaded", false);
    }


}
