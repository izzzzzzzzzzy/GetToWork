using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    SceneController controller;
    Timer timer;
    MinigameStartScreen startScreen;

    [SerializeField] private float timeRemaining = 30f;
    [SerializeField] private float score;
    public TMP_Text scoreShow;

    public string[] limbsToBeDamagedNames;

    private bool gameOver;

    private void Start()
    {
        timer = GetComponentInChildren<Timer>();
        timer.gameObject.SetActive(false);
        startScreen = GetComponentInChildren<MinigameStartScreen>();

        scoreShow.text = "$" + score;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        timer.SetTime(timeRemaining);
        scoreShow.text = "$" + score;

        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            timer.gameObject.SetActive(false);

            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame(score, limbsToBeDamagedNames);
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
