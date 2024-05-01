using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        SceneController.inputsEnabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator.SetBool("isFaded", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isFaded", false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneController.inputsEnabled = true;
    }


}
