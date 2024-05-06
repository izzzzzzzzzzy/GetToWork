using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        audioSource.Play();
        if (SceneController.Instance.inMinigame)
        {
            FindFirstObjectByType<MinigameController>().SetTimeRemaining(0);
            SceneController.Instance.PlayGame();
        }
        else
        {
            SceneController.Instance.PlayGame();
            Application.Quit();
        }
    }
}
