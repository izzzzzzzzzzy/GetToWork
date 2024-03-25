using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndButtonScript : MonoBehaviour
{
    public Button endButton;
    //MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = endButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        //mainManager = mainManager.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        MainManager.Instance.debt = 500000f;
        MainManager.Instance.money = 0f;
        MainManager.Instance.timeRemaining = 120;
        SceneManager.LoadScene("StartScreen");
    }
}
