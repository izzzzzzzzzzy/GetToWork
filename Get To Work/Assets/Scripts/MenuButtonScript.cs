using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void GoToMenu()
    {
        audioSource.Play();
        SceneController.Instance.PlayGame();

        if (SceneController.Instance.inMinigame)
        {
            MinigameController controller = FindFirstObjectByType<MinigameController>();
            controller.StartGame();
            SceneController.Instance.EndMinigame(0);
        }
        else
        {
            SceneController.Instance.RestartGame();
        }
    }
}
