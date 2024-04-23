using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Popup : MonoBehaviour, IInteractable
{
    AudioSource audioSource;
    Canvas popup;

    [SerializeField] private AudioClip onSound;
    [SerializeField] private AudioClip offSound;

    private bool isActive;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        popup = GetComponentInChildren<Canvas>();

        popup.gameObject.SetActive(false);
    }
    public void Interact(GameObject player) {
        isActive = !isActive;
        popup.gameObject.SetActive(isActive);

        if (isActive) {
            audioSource.clip = onSound;
        }
        else
        {
            audioSource.clip = offSound;
        }
        audioSource.Play();

        PlayerBase playerBase = player.GetComponent<PlayerBase>();
        playerBase.SetCanWalk(!isActive);
    }
}
