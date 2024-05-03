using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndButtonScript : MonoBehaviour
{
    public Button endButton;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = endButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        audioSource.Play();
        MainManager.Instance.fileName = "";
        MainManager.Instance.debt = 1500f;
        MainManager.Instance.money = 0;
        MainManager.Instance.dayNum = 0;
        MainManager.Instance.timeRemaining = 120;
        MainManager.Instance.limbHealths = new int[] {100, 100, 100, 100, 100, 100};
        SceneManager.LoadScene("StartScreen");
    }
}
