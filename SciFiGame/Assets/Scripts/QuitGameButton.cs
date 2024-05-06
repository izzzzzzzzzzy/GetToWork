using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    public Button endButton;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = endButton.GetComponent<Button>();

        audioSource = btn.GetComponent<AudioSource>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        audioSource.Play();
        Application.Quit();
    }
}