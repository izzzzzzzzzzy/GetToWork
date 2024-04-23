using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTransition : MonoBehaviour, IInteractable
{
    SceneController controller;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    [SerializeField] private string nextScene;
    [SerializeField] private Vector3 returnOffset;

    private void Start()
    {
        controller = SceneController.Instance;

        audioSource = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Interact(GameObject player)
    {
        controller.StartMinigame(nextScene, transform.position + returnOffset);
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
