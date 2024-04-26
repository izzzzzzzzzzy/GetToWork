using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour, ISaveable
{
    public static MainManager Instance;

    //Player stats
    public float debt;
    public float money;
    public int rArmHealth;
    public int lArmHealth;
    public int rLegHealth;
    public int lLegHealth;
    public int[] limbHealth = new int[6];

//timers
    public float dayTime = 180;
    public float timeRemaining;
    public int dayNum;

    //Save data
    public string fileName = "";

    private bool dayStarted;

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
        timeRemaining = dayTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (dayStarted)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void StartDay()
    {
        timeRemaining = dayTime;
        dayStarted = true;
    }

    public void FillBaseData()
    {
        debt = 2000;
        money = 0;
        dayNum = 0;
        rArmHealth = 100;
        lArmHealth = 100;
        rLegHealth = 100;
        lLegHealth = 100;
        limbHealth = new int[] {100, 100, 100, 100, 100, 100};
    }

    //Saving and loading
    public void SaveJsonData(MainManager mm){
        SaveData sd = new();
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
        sd.limbHealth = limbHealth;
        sd.dayNum = dayNum;
    }

    public bool LoadJsonData(MainManager mm, string name){
        if(FileManager.LoadFromFile(name, out var json)){
            SaveData sd = new();
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
        limbHealth = sd.limbHealth;
        rArmHealth = sd.rArmHealth;
        lArmHealth = sd.lArmHealth;
        rLegHealth = sd.rLegHealth;
        lLegHealth = sd.lLegHealth;
        dayNum = sd.dayNum;
    }

    public SaveData ShowJsonData(MainManager mm, string name){
        if(FileManager.LoadFromFile(name, out var json)){
            SaveData sd = new();
            sd.LoadFromJson(json);
            Debug.Log("Load complete");
            return sd;
        }
        else{
            Debug.Log("Could not load " + name + ", making new blank");
            SaveData sd = new()
            {
                debt = 10000,
                money = 0,
                dayNum = 0,
                isEmpty = true,
                limbHealth = new int[] {100, 100, 100, 100, 100, 100}

            };
            return sd;
        }
    }
}
