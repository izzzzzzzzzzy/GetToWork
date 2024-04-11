using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainRoomController : MonoBehaviour
{
    SceneController controller;
    Clock clock;

    [SerializeField] private float timeRemaining;
    [SerializeField] private float score;
    public TMP_Text scoreShow;

    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<SceneController>();
        clock = GetComponentInChildren<Clock>();
        timeRemaining = MainManager.Instance.timeRemaining;
        score = MainManager.Instance.money;
        scoreShow.text = "$" + score;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = MainManager.Instance.timeRemaining;
        clock.SetAngle(timeRemaining);

        if (!gameOver && timeRemaining <= 0)
        {
            gameOver = true;

            clock.gameObject.SetActive(false);
            if(controller == null){
                controller = FindFirstObjectByType<SceneController>();
            }
            controller.EndDay();
        }
    }
}
