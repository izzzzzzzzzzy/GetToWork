using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameDoor : Interactable
{
    SceneController controller;
    MainManager mainManager;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource; 
    Popup popup;
    Collider2D coll;

    [SerializeField] private string nextScene;
    [SerializeField] private Vector3 returnOffset;
    [SerializeField] private string limb;

    private string[] limbIndices = new string[] { "headHealth", "eyeHealth", "lArmHealth", "rArmHealth", "lLegHealth", "rLegHealth" };
    private int limbIndex;
    

    private void Start()
    {
        controller = SceneController.Instance;
        mainManager = MainManager.Instance;

        audioSource = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        popup = gameObject.GetComponentInChildren<Popup>();
        coll = gameObject.GetComponent<Collider2D>();

        limbIndex = Array.IndexOf(limbIndices, limb);
    }

    private void Update()
    {
        SetActive(mainManager.limbHealths[limbIndex] > 0);
        popup.gameObject.SetActive(!IsActive());
        coll.enabled = IsActive();

        if (!IsActive())
        {
            spriteRenderer.color = Color.red;
        }
    }

    public override void Interact(GameObject player)
    {
        controller.StartMinigame(nextScene, transform.position + returnOffset, limbIndex);
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
