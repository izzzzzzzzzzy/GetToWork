using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainRoomController : MonoBehaviour
{
    Clock clock;

    [SerializeField] private float timeRemaining;
    [SerializeField] private float score;
    public TMP_Text scoreShow;

    private bool dayEnded;
    public NoInteractPopup popupOpen;
    public bool tutorialRead = true;

    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponentInChildren<Clock>();
        timeRemaining = MainManager.Instance.timeRemaining;
        score = MainManager.Instance.money;
        scoreShow.text = "¶" + score;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = MainManager.Instance.timeRemaining;
        clock.SetAngle(timeRemaining);

        if (!dayEnded && (timeRemaining <= 0 || SceneController.Instance.IsDead()))
        {
            dayEnded = true;
            StartCoroutine(EndDay());
        }
    }

    IEnumerator EndDay()
    {
        while (SceneController.screenFading)
        {
            yield return new WaitForSeconds(0.1f);
        }

        if (SceneController.Instance.IsDead())
        {
            SceneController.Instance.GameOver();
        }
        else
        {
            SceneController.Instance.EndDay();
        }
    }
}
