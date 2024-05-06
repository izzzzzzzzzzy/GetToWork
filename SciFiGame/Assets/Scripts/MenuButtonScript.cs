using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToMenu);
    }

    void GoToMenu()
    {
        audioSource.Play();
        SceneController.Instance.PlayGame();

        if (SceneController.Instance.inMinigame)
        {
            MinigameController controller = FindFirstObjectByType<MinigameController>();
            controller.StartGame();
            controller.SetTimeRemaining(0);
        }
        else
        {
            SceneController.Instance.RestartGame();
        }
    }
}
