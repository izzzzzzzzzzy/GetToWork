using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void QuitGame()
    {
        audioSource.Play();
        SceneController.Instance.PlayGame();
        Application.Quit();
    }
}
