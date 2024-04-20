using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : Interactable
{
    public Canvas popUp;
    void Start() {
        popUp.gameObject.SetActive(false);
    }
    override public void Interact(GameObject player) {
        popUp.gameObject.SetActive(true);
    }
}
