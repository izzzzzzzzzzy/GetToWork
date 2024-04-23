using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    SceneController controller;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    [SerializeField] private Vector2 nPlayerPos;
    [SerializeField] private Vector2 nCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = SceneController.Instance;

        audioSource = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Interact(GameObject player)
    {
        controller.EnterDoor(player, nPlayerPos, nCameraPos);
        MainManager.Instance.StartDay();
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
