using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTransition : Interactable
{
    SceneController sceneController;

    [SerializeField] private string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindFirstObjectByType<SceneController>();
    }

    override public void Interact(GameObject player)
    {
        StartCoroutine(sceneController.ChangeScene(sceneName));
    }
}
