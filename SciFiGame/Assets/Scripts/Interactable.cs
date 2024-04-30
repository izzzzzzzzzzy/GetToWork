using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    private bool isActive = true;
    public bool IsActive()
    {
        return isActive;
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;
    }
    public abstract void Interact(GameObject player);
}
