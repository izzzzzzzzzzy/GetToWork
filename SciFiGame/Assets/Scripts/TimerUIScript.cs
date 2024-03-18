using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUIScript : MonoBehaviour
{
    public TMP_Text timer;
    public float timeSeconds;
    public float timeMinutes;
    // Start is called before the first frame update
    void Start()
    {
        timer = timer.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSeconds <= 0 && timeMinutes <= 0){
            //TODO: end game
        }
        else if(timeSeconds <= 0){
            timeSeconds = 60f;
            timeMinutes -= 1f;
        }
        else{
            timeSeconds -= Time.deltaTime;
        }

        if(timeSeconds >= 10){
            timer.text = timeMinutes + ":" + (int)timeSeconds;
        }
        else{
            timer.text = timeMinutes + ":0" + (int)timeSeconds;
        }
    }
}
