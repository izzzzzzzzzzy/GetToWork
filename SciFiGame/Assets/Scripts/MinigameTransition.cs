using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTransition : Interactable
{   

    [SerializeField] private string nextScene;
    [SerializeField] private Vector3 returnOffset;

    override public void Interact(GameObject player)
    {
        FindFirstObjectByType<SceneController>().StartMinigame(nextScene, transform.position + returnOffset);
    }
}
