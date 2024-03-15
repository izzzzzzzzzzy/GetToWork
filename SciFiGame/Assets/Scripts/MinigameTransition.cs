using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTransition : Interactable
{
    SceneController sceneController;

    [SerializeField] private string nextScene;
    [SerializeField] private Vector3 returnOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindFirstObjectByType<SceneController>();
    }

    override public void Interact(GameObject player)
    {
        sceneController.StartMinigame(nextScene, transform.position + returnOffset);
    }
}
