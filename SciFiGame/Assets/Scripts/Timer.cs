using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timer = timer.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = string.Format("{0}:{1:00}", (int)timeRemaining / 60, (int)timeRemaining % 60);

        timeRemaining -= Time.deltaTime;
    }

    public void SetTimeRemaining(float seconds)
    {
        timeRemaining = seconds;
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }
}
