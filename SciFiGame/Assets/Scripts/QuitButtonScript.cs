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
        SceneController.Instance.PlayGame();
        Application.Quit();
    }
}
