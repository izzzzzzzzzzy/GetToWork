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
        mainManager = controller.GetComponent<MainManager>();
        controller = controller.GetComponent<SceneController>();
        gameTime = (mainManager.dayTimeLeftMinutes * 60 ) + mainManager.dayTimeLeftSeconds;
        timeRemaining = gameTime;

        timer = timer.GetComponent<Timer>();
        timer.SetTimeRemaining(gameTime);
        score = mainManager.money;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timer.SetTimeRemaining(timeRemaining);
        //timeRemaining = timer.GetTimeRemaining();


        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            timer.gameObject.SetActive(false);
            EndDay();
        }
    }

    void EndDay(){
        SceneManager.LoadScene("EndOfDay");
    }
}
