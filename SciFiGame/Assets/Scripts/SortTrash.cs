using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortTrash : MonoBehaviour
{
    SceneController controller;

    [SerializeField] private float gameTime = 60f;
    //[SerializeField] private float target = 20f;
    [SerializeField] private float score;

    private bool gameOver;

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime < 0 && !gameOver)
        {
            gameOver = true;

            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame();
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void DecreaseScore()
    {
        score--;
    }
}
