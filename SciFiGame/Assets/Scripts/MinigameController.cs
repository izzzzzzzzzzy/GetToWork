using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    SceneController controller;
    Timer timer;
    MinigameStartScreen startScreen;

    [SerializeField] private float gameTime = 60f;
    [SerializeField] private float score;

    private bool gameOver;
    private float timeRemaining;

    private void Start()
    {
        timer = GetComponentInChildren<Timer>();
        timer.SetTimeRemaining(gameTime);
        timer.gameObject.SetActive(false);
        startScreen = GetComponentInChildren<MinigameStartScreen>();

        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = timer.GetTimeRemaining();

        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            timer.gameObject.SetActive(false);

            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame((int)gameTime%60, (int)gameTime/60, (int)score);
        }
    }

    public void IncreaseScore(int amt)
    {
        score += amt;
    }

    public void DecreaseScore(int amt)
    {
        score -= amt;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startScreen.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
    }

    public float GetTimeRemaining(){
        return timeRemaining;
    }
}
