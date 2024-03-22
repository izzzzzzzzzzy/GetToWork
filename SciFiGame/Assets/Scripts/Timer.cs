using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timer.GetComponent<TMP_Text>();
    }

    public void SetTime(float seconds)
    {
        timer.text = string.Format("{0}:{1:00}", (int)(seconds / 60), (int)(seconds % 60));
    }
}
