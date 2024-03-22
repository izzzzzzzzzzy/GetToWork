using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoomController : MonoBehaviour
{
    SceneController controller;
    Timer timer;
    MainManager mainManager;

    [SerializeField] private float timeRemaining;
    [SerializeField] private float score;

    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<SceneController>();
        mainManager = controller.GetComponent<MainManager>();
        timer = GetComponentInChildren<Timer>();

        timeRemaining = mainManager.dayTimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = mainManager.dayTimeLeft;
        timer.SetTime(timeRemaining);

        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            timer.gameObject.SetActive(false);
            controller.EndDay();
        }
    }
}
