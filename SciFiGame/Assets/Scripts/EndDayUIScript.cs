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
    public TMP_InputField payDebtInput;
    public int payDebtInputMin = 1;

    public Toggle payRent;
    public Toggle payOxygen;
    public Toggle payRepair;

    public AudioSource toggleSFX;

    public TMP_Text debt;
    public TMP_Text moneyHave;
    public TMP_Text moneyRemaining;
    public TMP_Text dayCounter;

    public float debtValue;
    public float moneyValue;
    public float totalCost;
    private bool cantPay = false;

    public GameObject oxygenWarning;
    int input = 0;

    void Start()
    {
        //all the buttons
        Button btn = nextDayButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        toggleSFX = toggleSFX.GetComponent<AudioSource>();

        payDebt = payDebt.GetComponent<Toggle>();
        payDebt.isOn = true;
        payDebt.onValueChanged.AddListener(delegate {DebtToggleActivated(payDebt);});
        payDebtInput = payDebtInput.GetComponent<TMP_InputField>();
        payDebtInput.text = "0";
        payDebtInput.onEndEdit.AddListener(delegate {DebtToggleActivated(payDebt);});
        payDebtInput.onEndEdit.AddListener(delegate {DebtInputChanged(payDebt);});

        payRent = payRent.GetComponent<Toggle>();
        payRent.isOn = true;
        payRent.onValueChanged.AddListener(delegate {ToggleActivated(payRent, 10);});

        payOxygen = payOxygen.GetComponent<Toggle>();
        payOxygen.isOn = true;
        payOxygen.onValueChanged.AddListener(delegate {ToggleActivated(payOxygen, 5);});

        payRepair = payRepair.GetComponent<Toggle>();
        payRepair.isOn = true;
        payRepair.onValueChanged.AddListener(delegate {ToggleActivated(payRepair, 30);});

        debt = debt.GetComponent<TMP_Text>();
        moneyRemaining = moneyRemaining.GetComponent<TMP_Text>();
        dayCounter = dayCounter.GetComponent<TMP_Text>();

        totalCost = 45;
        debtValue = MainManager.Instance.debt;
        moneyValue = MainManager.Instance.money;
        dayCounter.text = "Day " + MainManager.Instance.dayNum;

        oxygenWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //these two are mostly here for when changing values during testing
        //not neccessary otherwise
        debtValue = MainManager.Instance.debt;
        moneyValue = MainManager.Instance.money;

        payDebtInput.enabled = payDebt.isOn;

        try {
            input = int.Parse(payDebtInput.text);

        } catch (System.Exception e) {
            input = 0;
        }

        if (input < 0){
            payDebtInput.text = "0";
        }

        moneyHave.text = "¶" + moneyValue;
        debt.text = "¶" + debtValue;
        moneyRemaining.text = "= ¶" + (moneyValue-totalCost - input) + ".00";

        if(moneyValue-totalCost - input < 0){
            moneyRemaining.text = "<color=#B0221D>" + moneyRemaining.text;
            cantPay = true;
        }
        else{
            moneyRemaining.text = "<color=#FFFFFF>" + moneyRemaining.text;
            cantPay = false;
        }

        if(cantPay == true){
            nextDayButton.interactable = false;
        }
        else{
            nextDayButton.interactable = true;
        }


    }
    void TaskOnClick()
    {
        toggleSFX.Play();
        if(payOxygen.isOn == false){
            oxygenWarning.SetActive(true);
        }
        else if(payRent.isOn == false){
            oxygenWarning.SetActive(true);
        }
        else if(cantPay == true){
            //should not get here because of above, but just in case
            Debug.Log("warning about money");
        }
        else if(payRepair.isOn == false && CheckLimbsBroken()){
            //check for if limbs are <=0 and you don't choose to heal them
            oxygenWarning.SetActive(true);
        }
        else{
            //setting up for next day and saving game
            MainManager.Instance.debt -= input;
            if(MainManager.Instance.debt > 0){
                //repair limbs health if you chose too
                if(payRepair.isOn){
                    for (int i = 0; i < 6; i++){
                        MainManager.Instance.limbHealths[i] += 30;
                        if (MainManager.Instance.limbHealths[i] > 100)
                        {
                            MainManager.Instance.limbHealths[i] = 100;
                        }
                    }
                }
                MainManager.Instance.money -= totalCost + input;
                MainManager.Instance.timeRemaining = MainManager.Instance.dayTime;
                MainManager.Instance.dayNum += 1;
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                FindFirstObjectByType<SceneController>().StartDay();
            }
            else{
                //for if they win the game
                MainManager.Instance.debt = 0;
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                SceneController.Instance.ChangeScene("WinScreen");
            }
        }

    }

    private bool CheckLimbsBroken()
    {
        foreach (int health in MainManager.Instance.limbHealths){
            if (health > 0)
            {
                return false;
            }
        }
        return true;
    }

    void ToggleActivated(Toggle toggle, int cost){
        toggleSFX.Play();
        if(toggle.isOn){
            totalCost += cost;
            toggle.GetComponentInChildren<TMP_Text>().enabled = true;
        }
        else{
            totalCost -= cost;
            toggle.GetComponentInChildren<TMP_Text>().enabled = false;
        }
    }

    void DebtToggleActivated(Toggle toggle){
        toggleSFX.Play();
        if(toggle.isOn){
            toggle.GetComponentInChildren<TMP_Text>().enabled = true;
        }
        else{
            toggle.GetComponentInChildren<TMP_Text>().enabled = false;
        }
    }

    void DebtInputChanged(Toggle toggle){
        if(toggle.isOn){
            toggle.GetComponentInChildren<TMP_Text>().text = "-¶" + input.ToString() + ".00";
        }
    }
}
