using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashChute : MonoBehaviour
{

    [Header("Types: 0 = trash, 1 = glass, 2 = compost, 3 = cardboard")]
    [SerializeField] private int binType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetBinType()
    {
        return binType;
    }
}
