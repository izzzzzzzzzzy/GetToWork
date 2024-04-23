using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadSceneUIScript : MonoBehaviour
{
    public AudioSource buttonSound;

    public Button loadScreen;
    public Button newGame;

    public GameObject loadsOptions;
    public TMP_Text saveOrLoadText;
    public Button saveFile1;
    public TMP_Text saveFile1Description;
    public Button saveFile2;
    public TMP_Text saveFile2Description;
    public Button saveFile3;
    public TMP_Text saveFile3Description;
    public Button goBack;

    public GameObject yesOrNoLoad;
    private TMP_Text confirmationText;
    public Button confirmLoad;
    public Button cancelLoad;

    private bool isNewGame;

    private bool[] savesExist = new bool[3];

    void Start()
    {
        confirmationText = yesOrNoLoad.GetComponentInChildren<TMP_Text>();
        yesOrNoLoad.SetActive(false);


        loadScreen = loadScreen.GetComponent<Button>();
        loadScreen.onClick.AddListener(delegate {ShowLoads(false);});
        loadScreen.onClick.AddListener(ButtonSound);

        newGame = newGame.GetComponent<Button>();
        newGame.onClick.AddListener(delegate {ShowLoads(true);});
        newGame.onClick.AddListener(ButtonSound);

        goBack = goBack.GetComponent<Button>();
        goBack.onClick.AddListener(HideLoads);
        goBack.onClick.AddListener(ButtonSound);

        loadsOptions.SetActive(false);
        saveOrLoadText = saveOrLoadText.GetComponent<TMP_Text>();

        saveFile1 = saveFile1.GetComponent<Button>();
        saveFile1.onClick.AddListener(delegate {ShowConfirmationButton("SaveData1.dat"); });
        saveFile1.onClick.AddListener(ButtonSound);
        saveFile1Description = saveFile1Description.GetComponent<TMP_Text>();
        ShowSaveInfo("SaveData1.dat", saveFile1Description, 1);

        saveFile2 = saveFile2.GetComponent<Button>();
        saveFile2.onClick.AddListener(delegate {ShowConfirmationButton("SaveData2.dat");} );
        saveFile2.onClick.AddListener(ButtonSound);
        saveFile2Description = saveFile2Description.GetComponent<TMP_Text>();
        ShowSaveInfo("SaveData2.dat", saveFile2Description, 2);

        saveFile3 = saveFile3.GetComponent<Button>();
        saveFile3.onClick.AddListener(delegate {ShowConfirmationButton("SaveData3.dat");} );
        saveFile3.onClick.AddListener(ButtonSound);
        saveFile3Description = saveFile3Description.GetComponent<TMP_Text>();
        ShowSaveInfo("SaveData3.dat", saveFile3Description, 3);

        confirmLoad = confirmLoad.GetComponent<Button>();
        confirmLoad.onClick.AddListener(LoadSave);
        confirmLoad.onClick.AddListener(ButtonSound);

        cancelLoad = cancelLoad.GetComponent<Button>();
        cancelLoad.onClick.AddListener(HideConfirmationButton);
        cancelLoad.onClick.AddListener(ButtonSound);

    }

    void ShowLoads(bool newGame){
        isNewGame = newGame;
        loadsOptions.SetActive(true);

        if (isNewGame){
            saveOrLoadText.text = "New Game";
            confirmationText.text = "Start new game?";

            saveFile1.interactable = true;
            saveFile2.interactable = true;
            saveFile3.interactable = true;
        }
        else{
            saveOrLoadText.text = "Load Game";
            confirmationText.text = "Load this save?";

            saveFile1.interactable = savesExist[0];
            saveFile2.interactable = savesExist[1];
            saveFile3.interactable = savesExist[2];
        }

    }

    void HideLoads(){
        loadsOptions.SetActive(false);
    }

    void ShowConfirmationButton(string i){
        MainManager.Instance.fileName = i;
        yesOrNoLoad.SetActive(true);
    }

    void HideConfirmationButton(){
        MainManager.Instance.fileName = "";
        yesOrNoLoad.SetActive(false);
    }

    void LoadSave(){
        if(!isNewGame){
            if(MainManager.Instance.LoadJsonData(MainManager.Instance, MainManager.Instance.fileName)){
                Debug.Log("loaded!");
                SceneController.Instance.StartDay();
            }
            else if(MainManager.Instance.fileName != ""){
                Debug.Log("file not made yet!");
                MainManager.Instance.debt = 10000;
                MainManager.Instance.money = 0;
                MainManager.Instance.dayNum = 0;
                MainManager.Instance.rArmHealth = 100;
                MainManager.Instance.lArmHealth = 100;
                MainManager.Instance.rLegHealth = 100;
                MainManager.Instance.lLegHealth = 100;
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                MainManager.Instance.LoadJsonData(MainManager.Instance, MainManager.Instance.fileName);
                SceneController.Instance.StartDay();
            }
            else{
                Debug.Log("file name blank!");
            }
        }
        else{
            if(MainManager.Instance.fileName != ""){
                Debug.Log("Overwriting save data");
                MainManager.Instance.debt = 10000;
                MainManager.Instance.money = 0;
                MainManager.Instance.dayNum = 0;
                MainManager.Instance.rArmHealth = 100;
                MainManager.Instance.lArmHealth = 100;
                MainManager.Instance.rLegHealth = 100;
                MainManager.Instance.lLegHealth = 100;
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                MainManager.Instance.LoadJsonData(MainManager.Instance, MainManager.Instance.fileName);
                SceneController.Instance.PlayBackstory();

            }
            else{
                Debug.Log("file name blank!");
            }
        }
    }

    void ShowSaveInfo(string name, TMP_Text texty, int saveNum){
        SaveData values = MainManager.Instance.ShowJsonData(MainManager.Instance, name);
        if (!values.isEmpty && values.dayNum!=0)
        {
            texty.text = "Day: " + values.dayNum + "\nDebt: " + values.debt + "\nMoney: " + values.money;
            savesExist[saveNum - 1] = true;
        }
        else
        {
            texty.text = "Empty";
        }
    }

    public void ButtonSound() {
        buttonSound.Play();
    }
}
