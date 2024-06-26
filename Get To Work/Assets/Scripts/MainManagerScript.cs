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
    public float debt = 1500;
    public float money = 0;
    public int[] limbHealths = new int[] {100, 100, 100, 100, 100, 100};

//timers
    public float dayTime = 180;
    public float timeRemaining;
    public int dayNum = 1;

    //Save data
    public string fileName = "";

    public bool dayStarted;

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
        if (dayStarted && !SceneController.Instance.IsPaused() && !SceneController.screenFading)
        {
            if (SceneController.Instance.inMinigame)
            {
                if (FindFirstObjectByType<MinigameController>().gameStarted)
                {
                    timeRemaining -= Time.unscaledDeltaTime;
                }
            }
            else
            {
                timeRemaining -= Time.unscaledDeltaTime;
            }
        }
    }

    public void StartDay()
    {
        timeRemaining = dayTime;
        dayStarted = true;
    }

    public void FillBaseData()
    {
        debt = 1500;
        money = 0;
        dayNum = 1;
        limbHealths = new int[] {100, 100, 100, 100, 100, 100};
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
        sd.limbHealths = limbHealths;
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
        limbHealths = sd.limbHealths;
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
                debt = 1500,
                money = 0,
                dayNum = 1,
                isEmpty = true,
                limbHealths = limbHealths
            };

            return sd;
        }
    }
}
