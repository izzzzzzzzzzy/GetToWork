using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndDayUIScript : MonoBehaviour
{
    public Button nextDayButton;
    public string nextLevelName;

    public Toggle payDebt;
    public Toggle payRent;
    public Toggle payOxygen;
    public Toggle payFood;
    public Toggle payHeating;
    public Toggle payRepair;

    public TMP_Text debt;
    public TMP_Text moneyRemaining;

    public float debtValue;
    public float moneyValue;
    public float totalCost;

    void Start()
    {
        Button btn = nextDayButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        payDebt = payDebt.GetComponent<Toggle>();
        payDebt.onValueChanged.AddListener(delegate {ToggleActivated(payDebt, 1);});

        payRent = payRent.GetComponent<Toggle>();
        payRent.onValueChanged.AddListener(delegate {ToggleActivated(payRent, 1);});

        payOxygen = payOxygen.GetComponent<Toggle>();
        payOxygen.onValueChanged.AddListener(delegate {ToggleActivated(payOxygen, 1);});

        payFood = payFood.GetComponent<Toggle>();
        payFood.onValueChanged.AddListener(delegate {ToggleActivated(payFood, 1);});

        payHeating = payHeating.GetComponent<Toggle>();
        payHeating.onValueChanged.AddListener(delegate {ToggleActivated(payHeating, 1);});

        payRepair = payRepair.GetComponent<Toggle>();
        payRepair.onValueChanged.AddListener(delegate {ToggleActivated(payRepair, 1);});

        debt = debt.GetComponent<TMP_Text>();
        moneyRemaining = moneyRemaining.GetComponent<TMP_Text>();

        totalCost = 6;
        //TODO: add references to values in MainManager for debt + money
    }

    // Update is called once per frame
    void Update()
    {
        moneyRemaining.text = "= $" + (moneyValue-totalCost) + ".00";
    }
    void TaskOnClick()
    {
        if(debt.enabled == false){
            //TODO have warning popup
            print("warning about debt");
        }
        else{
            SceneManager.LoadScene(nextLevelName);
        }

    }

    void ToggleActivated(Toggle toggle, int cost){
        if(toggle.isOn){
            totalCost +=1;
            toggle.GetComponentInChildren<TMP_Text>().enabled = true;
        }
        else{
            totalCost -=1;
            toggle.GetComponentInChildren<TMP_Text>().enabled = false;
        }
    }
}
