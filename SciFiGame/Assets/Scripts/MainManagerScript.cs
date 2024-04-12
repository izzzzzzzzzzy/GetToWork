using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour, ISaveable
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
    public int dayNum;

    //Save data
    public string fileName = "";


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

    //Saving and loading
    public void SaveJsonData(MainManager mm){
        SaveData sd = new SaveData();
        mm.PopulateSaveData(sd);

        if(FileManager.WriteToFile(mm.fileName, sd.ToJson())){
            Debug.Log("Save Successful");
        }

    }

    public void PopulateSaveData(SaveData sd){
        sd.name = fileName;
        sd.debt = debt;
        sd.money = money;
        sd.rArmHealth = rArmHealth;
        sd.lArmHealth = lArmHealth;
        sd.rLegHealth = rLegHealth;
        sd.lLegHealth = lLegHealth;
        sd.dayNum = dayNum;
    }

    public bool LoadJsonData(MainManager mm, string name){
        if(FileManager.LoadFromFile(name, out var json)){
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            mm.LoadFromSaveData(sd);
            Debug.Log("Load complete");
            return true;
        }
        else{
            Debug.Log("Could not load " + name);
            return false;
        }
    }

    public void LoadFromSaveData(SaveData sd){
        fileName = sd.name;
        debt = sd.debt;
        money = sd.money;
        rArmHealth = sd.rArmHealth;
        lArmHealth = sd.lArmHealth;
        rLegHealth = sd.rLegHealth;
        lLegHealth = sd.lLegHealth;
        dayNum = sd.dayNum;
    }

    public SaveData ShowJsonData(MainManager mm, string name){
        if(FileManager.LoadFromFile(name, out var json)){
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);
            Debug.Log("Load complete");
            return sd;
        }
        else{
            Debug.Log("Could not load " + name + ", making new blank");
            SaveData sd = new SaveData();
            sd.debt = 10000;
            sd.money = 0;
            sd.dayNum = 0;
            sd.isEmpty = true;
            return sd;
        }
    }
}
