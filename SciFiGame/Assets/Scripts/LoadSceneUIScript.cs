using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadSceneUIScript : MonoBehaviour
{
    public Button loadScreen;
    public Button newGame;

    public GameObject loadsOptions;
    public TMP_Text saveOrLoadText;
    public Button saveFile1;
    public Button saveFile2;
    public Button saveFile3;
    public Button goBack;

    public GameObject yesOrNoLoad;
    private TMP_Text confirmationText;
    public Button confirmLoad;
    public Button cancelLoad;

    private bool isNewGame;

    void Start()
    {
        confirmationText = yesOrNoLoad.GetComponentInChildren<TMP_Text>();
        yesOrNoLoad.SetActive(false);


        loadScreen = loadScreen.GetComponent<Button>();
        loadScreen.onClick.AddListener(delegate {ShowLoads(false);});
        newGame = newGame.GetComponent<Button>();
        newGame.onClick.AddListener(delegate {ShowLoads(true);});
        goBack = goBack.GetComponent<Button>();
        goBack.onClick.AddListener(HideLoads);
        loadsOptions.SetActive(false);
        saveOrLoadText = saveOrLoadText.GetComponent<TMP_Text>();

        saveFile1 = saveFile1.GetComponent<Button>();
        saveFile1.onClick.AddListener(delegate {ShowConfirmationButton("SaveData1.dat"); });
        saveFile2 = saveFile2.GetComponent<Button>();
        saveFile2.onClick.AddListener(delegate {ShowConfirmationButton("SaveData2.dat");} );
        saveFile3 = saveFile3.GetComponent<Button>();
        saveFile3.onClick.AddListener(delegate {ShowConfirmationButton("SaveData3.dat");} );

        confirmLoad = confirmLoad.GetComponent<Button>();
        confirmLoad.onClick.AddListener(LoadSave);
        cancelLoad = cancelLoad.GetComponent<Button>();
        cancelLoad.onClick.AddListener(HideConfirmationButton);
    }

    void ShowLoads(bool newGame){
        isNewGame = newGame;
        if(isNewGame){
            loadsOptions.SetActive(true);
            saveOrLoadText.text = "New Game";
            confirmationText.text = "Create new save?";
        }
        else{
            loadsOptions.SetActive(true);
            saveOrLoadText.text = "Load Game";
            confirmationText.text = "Load this save?";
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
                SceneManager.LoadScene("MainScene");
            }
            else if(MainManager.Instance.fileName != ""){
                Debug.Log("file not made yet!");
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                MainManager.Instance.LoadJsonData(MainManager.Instance, MainManager.Instance.fileName);
                SceneManager.LoadScene("MainScene");

            }
            else{
                Debug.Log("file name blank!");
            }
        }
        else{
            if(MainManager.Instance.fileName != ""){
                Debug.Log("Overwriting save data");
                MainManager.Instance.debt = 500000;
                MainManager.Instance.money = 0;
                MainManager.Instance.rArmHealth = 0;
                MainManager.Instance.lArmHealth = 0;
                MainManager.Instance.rLegHealth = 0;
                MainManager.Instance.lLegHealth = 0;
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                MainManager.Instance.LoadJsonData(MainManager.Instance, MainManager.Instance.fileName);
                SceneManager.LoadScene("MainScene");

            }
            else{
                Debug.Log("file name blank!");
            }
        }
    }
}
