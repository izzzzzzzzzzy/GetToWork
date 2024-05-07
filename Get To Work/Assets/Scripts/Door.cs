using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    SceneController controller;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    Popup popup;
    Collider2D coll;

    [SerializeField] private Vector2 nPlayerPos;
    [SerializeField] private Vector2 nCameraPos;
    [SerializeField] private bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        controller = SceneController.Instance;

        popup = GetComponentInChildren<Popup>();
        coll = GetComponentInChildren<Collider2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (isLocked)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
    }

    public override void Interact(GameObject player)
    {
        controller.EnterDoor(player, nPlayerPos, nCameraPos);
        MainManager.Instance.StartDay();
    }

    public void Lock()
    {
        SetActive(false);
        popup.gameObject.SetActive(true);
        coll.enabled = false;
        isLocked = false;
        spriteRenderer.color = Color.red;
    }

    public void Unlock()
    {
        SetActive(true);
        popup.gameObject.SetActive(false);
        coll.enabled = true;
        spriteRenderer.color = Color.white;
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
