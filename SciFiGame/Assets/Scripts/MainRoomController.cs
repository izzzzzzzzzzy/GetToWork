using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainRoomController : MonoBehaviour
{
    SceneController controller;
    Timer timer;

    [SerializeField] private float timeRemaining;
    [SerializeField] private float score;
    public TMP_Text scoreShow;

    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<SceneController>();
        timer = GetComponentInChildren<Timer>();


        timeRemaining = MainManager.Instance.timeRemaining;
        score = MainManager.Instance.money;
        scoreShow.text = "$" + score;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = MainManager.Instance.timeRemaining;
        timer.SetTime(timeRemaining);

        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            timer.gameObject.SetActive(false);
            controller.EndDay();
        }
    }
}
