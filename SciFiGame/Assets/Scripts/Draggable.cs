using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private float scaleSize = 1.1f;

    private Vector3 screenPoint;
    private Vector3 offset;
    private AudioSource audioSource;

    public bool dragging;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        if (!SceneController.Instance.IsPaused())
        {
            Vector3 curScreenPoint = new(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

            transform.localScale = scaleSize * Vector2.one;
            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        transform.localScale = Vector2.one;
        dragging = false;

        audioSource.Play();
    }

}
