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

    public IEnumerator FadeScreen(float fadeTime)
    {
        animator.SetBool("isFaded", true);
        yield return new WaitForSeconds(fadeTime);
        animator.SetBool("isFaded", false);
    }


}
