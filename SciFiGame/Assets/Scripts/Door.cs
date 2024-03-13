using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    SceneController controller;

    [SerializeField] private Vector2 nPlayerPos;
    [SerializeField] private Vector2 nCameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject player)
    {
        StartCoroutine(controller.Teleport(player, nPlayerPos, nCameraPos));
    }
}
