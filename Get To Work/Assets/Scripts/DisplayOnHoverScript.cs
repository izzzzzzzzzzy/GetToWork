using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOnHoverScript : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    public GameObject information;

    void Start(){
        information.SetActive(false);
    }

    void Update()
    {
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
        }
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    mouse_over = true;
    //    information.SetActive(true);
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    mouse_over = false;
    //    information.SetActive(false);
    //}
}
