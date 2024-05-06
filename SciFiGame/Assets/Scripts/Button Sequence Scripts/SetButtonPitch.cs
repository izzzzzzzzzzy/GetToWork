using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButtonPitch : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] private int pitch;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.pitch = Mathf.Pow(2, pitch / 12f);
    }

}
