using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    SceneController controller;
    TMP_Text timer;
    MinigameStartScreen startScreen;

    [SerializeField] private float gameTime = 60f;
    [SerializeField] private float score;

    private bool gameOver;
    private int mins;
    private int secs;

    private void Start()
    {
        timer = GetComponentInChildren<TMP_Text>();
        timer.gameObject.SetActive(false);
        startScreen = FindFirstObjectByType<MinigameStartScreen>();

        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime < 0 && !gameOver)
        {
            gameOver = true;

            timer.enabled = false;

            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame();
        }

        mins = (int)gameTime / 60;
        secs = (int)gameTime % 60;

        timer.text = string.Format("{0}:{1:00}", mins, secs);

        gameTime -= Time.deltaTime;
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
    
    public float GetGameTime(){
        return gameTime;
    }
}
