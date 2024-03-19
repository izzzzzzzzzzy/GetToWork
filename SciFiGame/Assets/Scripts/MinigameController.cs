using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    SceneController controller;
    TimerUIScript timer;

    [SerializeField] private float gameTime = 60f;
    [SerializeField] private float score;

    private bool gameOver;

    private void Start()
    {
        timer = GetComponentInChildren<TimerUIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime < 0 && !gameOver)
        {
            gameOver = true;

            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame();
        }

        gameTime -= Time.deltaTime;

        timer.timeMinutes = (int)gameTime / 60;
        timer.timeSeconds = (int)gameTime % 60;
    }

    public void IncreaseScore(int amt)
    {
        score += amt;
    }

    public void DecreaseScore(int amt)
    {
        score -= amt;
    }

    public float GetGameTime(){
        return gameTime;
    }
}
