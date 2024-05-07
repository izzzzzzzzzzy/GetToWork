using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerScript : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite clickedSprite;

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Input.mousePosition;
        transform.position = newPos;
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(ShowClickSprite());
        }
    }

    IEnumerator ShowClickSprite(){
        image.sprite = clickedSprite;
        yield return new WaitForSeconds(0.1f);
        image.sprite = defaultSprite;
    }
}
