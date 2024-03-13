using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTransition : MonoBehaviour, IInteractable
{
    SceneController sceneController;

    [SerializeField] private string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindFirstObjectByType<SceneController>();
    }

    public void interact(GameObject player)
    {
        StartCoroutine(sceneController.ChangeScene(sceneName));
    }
}
