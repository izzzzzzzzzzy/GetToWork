using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    private Color baseColor;

    public abstract void Interact(GameObject player);

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        baseColor = spriteRenderer.color;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.color = baseColor * 3f;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.color = baseColor;
        }
    }
}
