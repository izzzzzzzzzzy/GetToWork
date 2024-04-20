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

    public IEnumerator FadeScreen()
    {
        animator.SetBool("isFaded", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isFaded", false);
    }


}
