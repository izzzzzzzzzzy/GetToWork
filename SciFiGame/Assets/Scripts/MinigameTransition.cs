using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameTransition : Interactable
{
    SceneController controller;
    MainManager mainManager;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    [SerializeField] private string nextScene;
    [SerializeField] private Vector3 returnOffset;
    [SerializeField] private string limb = "rLegHealth";

    private string[] limbIndices = new string[] { "rLegHealth", "lLegHealth", "rArmHealth", "lArmHealth", "headHealth", "eyeHealth" };
    private int limbIndex;
    private bool isActive;

    private void Start()
    {
        controller = SceneController.Instance;
        mainManager = MainManager.Instance;

        audioSource = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        limbIndex = Array.IndexOf(limbIndices, limb);
    }

    private void Update()
    {
        isActive = mainManager.limbHealth[limbIndex] > 0;

        if (!isActive)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public override void Interact(GameObject player)
    {
        controller.StartMinigame(nextScene, transform.position + returnOffset);
    }

    public override bool IsActive()
    {
        return isActive;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.color = Color.black;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.color = Color.white;
        }
    }
}
