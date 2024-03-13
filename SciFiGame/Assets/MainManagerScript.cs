using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    //Player stats
    public int debt;
    public int money;
    public int rArmHealth;
    public int lArmHealth;
    public int rLegHealth;
    public int lLegHealth;

    //timers
    public int dayTimeLeftSeconds;
    public int dayTimeLeftMinutes;


    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}
