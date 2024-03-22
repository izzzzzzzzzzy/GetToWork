using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndButtonScript : MonoBehaviour
{
    public Button endButton;
    public MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = endButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        mainManager = mainManager.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        mainManager.debt = 500000f;
        mainManager.money = 0f;
        mainManager.timeRemaining = 120;
        SceneManager.LoadScene("StartScreen");
    }
}
