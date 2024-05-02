using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Popup : Interactable
{
    AudioSource audioSource;
    Canvas popup;

    [SerializeField] private AudioClip onSound;
    [SerializeField] private AudioClip offSound;

    private bool isOpen;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        popup = GetComponentInChildren<Canvas>();

        popup.gameObject.SetActive(false);
    }

    public override void Interact(GameObject player) {
        isOpen = !isOpen;
        popup.gameObject.SetActive(isOpen);

        if (isOpen) {
            audioSource.clip = onSound;
        }
        else
        {
            audioSource.clip = offSound;
        }
        audioSource.Play();

        PlayerBase.SetCanWalk(!isOpen);
    }
}
