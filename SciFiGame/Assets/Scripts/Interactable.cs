using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual bool IsActive()
    {
        return true;
    }
    public abstract void Interact(GameObject player);
}
