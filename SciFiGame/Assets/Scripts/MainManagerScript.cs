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
    public int dayTimeLeftSeconds;
    public int dayTimeLeftMinutes;


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
    }
    // Update is called once per frame
    void Update()
    {

    }
}
