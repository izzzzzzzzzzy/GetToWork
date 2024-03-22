using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    SceneController sceneController;

    public static MainManager Instance;

    //Player stats
    public float debt;
    public float money;
    public int rArmHealth;
    public int lArmHealth;
    public int rLegHealth;
    public int lLegHealth;

    //timers
    public float dayTime = 180;
    public float timeRemaining;


    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        sceneController = GetComponent<SceneController>();
        timeRemaining = dayTime;
    }
    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
    }

    public void StartDay()
    {
        timeRemaining = dayTime;
    }
}
