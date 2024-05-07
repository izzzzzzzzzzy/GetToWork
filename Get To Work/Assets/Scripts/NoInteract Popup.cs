using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoInteractPopup : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] Canvas popup;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        popup.gameObject.SetActive(false);
    }

    public void Open()
    {
        popup.gameObject.SetActive(true);
        PlayerBase.SetCanWalk(false);
    }

    public void Close() {
        popup.gameObject.SetActive(false);
        PlayerBase.SetCanWalk(true);

        audioSource.Play();
    }
}
