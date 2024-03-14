using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashChute : MonoBehaviour
{

    [Header("Colors: 0 = red, 1 = blue, 2 = green, 3 = yellow")]
    [SerializeField] private int color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetColor()
    {
        return color;
    }
}
