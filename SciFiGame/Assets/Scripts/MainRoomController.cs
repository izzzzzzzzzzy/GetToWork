using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoomController : MonoBehaviour
{
    public SceneController controller;
    public Timer timer;
    MainManager mainManager;

    [SerializeField] private float gameTime;
    [SerializeField] private float score;

    private bool gameOver;
    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<SceneController>();
        mainManager = controller.GetComponent<MainManager>();
        gameTime = mainManager.dayTimeLeft;
        timeRemaining = gameTime;

        timer = timer.GetComponent<Timer>();
        timer.SetTimeRemaining(gameTime);
        score = mainManager.money;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = timer.GetTimeRemaining();


        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            timer.gameObject.SetActive(false);
            controller.EndDay();
        }
    }
}
