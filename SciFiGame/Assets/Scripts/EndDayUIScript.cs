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
    public Toggle payFood;
    public Toggle payHeating;
    public Toggle payRepair;

    public TMP_Text debt;
    public TMP_Text moneyHave;
    public TMP_Text moneyRemaining;
    public TMP_Text dayCounter;

    public float debtValue;
    public float moneyValue;
    public float totalCost;
    private bool cantPay = false;

    [SerializeField] private float debtPaid = 1;
    public GameObject debtWarning;

    void Start()
    {
        Button btn = nextDayButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        payDebt = payDebt.GetComponent<Toggle>();
        payDebt.isOn = true;
        payDebt.onValueChanged.AddListener(delegate {DebtToggleActivated(payDebt);});
        payDebtInput = payDebtInput.GetComponent<TMP_InputField>();
        payDebtInput.text = "1";
        payDebtInput.onEndEdit.AddListener(delegate {DebtToggleActivated(payDebt);});
        payDebtInput.onEndEdit.AddListener(delegate {DebtInputChanged(payDebt);});


        payRent = payRent.GetComponent<Toggle>();
        payRent.isOn = true;
        payRent.onValueChanged.AddListener(delegate {ToggleActivated(payRent, 1);});

        payOxygen = payOxygen.GetComponent<Toggle>();
        payOxygen.isOn = true;
        payOxygen.onValueChanged.AddListener(delegate {ToggleActivated(payOxygen, 1);});

        payFood = payFood.GetComponent<Toggle>();
        payFood.isOn = true;
        payFood.onValueChanged.AddListener(delegate {ToggleActivated(payFood, 1);});

        payHeating = payHeating.GetComponent<Toggle>();
        payHeating.isOn = true;
        payHeating.onValueChanged.AddListener(delegate {ToggleActivated(payHeating, 1);});

        payRepair = payRepair.GetComponent<Toggle>();
        payRepair.isOn = true;
        payRepair.onValueChanged.AddListener(delegate {ToggleActivated(payRepair, 1);});

        debt = debt.GetComponent<TMP_Text>();
        moneyRemaining = moneyRemaining.GetComponent<TMP_Text>();
        dayCounter = dayCounter.GetComponent<TMP_Text>();

        totalCost = 5;
        //totalCostWithoutDebt = 5
        debtValue = MainManager.Instance.debt;
        moneyValue = MainManager.Instance.money;
        dayCounter.text = "Day " + MainManager.Instance.dayNum;

        debtWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //these two are mostly here for when changing values during testing
        //not neccessary otherwise
        debtValue = MainManager.Instance.debt;
        moneyValue = MainManager.Instance.money;

        payDebtInput.enabled = payDebt.isOn;
        if(int.Parse(payDebtInput.text) < 1){
            payDebtInput.text = "1";
        }

        //if(totalCost != totalCostWithoutDebt + int.Parse(payDebtInput.text)){
        //    totalCost = totalCostWithoutDebt + int.Parse(payDebtInput.text);
        //}
        //payDebtInput.onEndEdit.AddListener(delegate{(ToggleActivated(payDebt, int.Parse(payDebtInput.text)));} );

        moneyHave.text = "$" + moneyValue;
        debt.text = "$" + debtValue;
        moneyRemaining.text = "= $" + (moneyValue-totalCost - int.Parse(payDebtInput.text)) + ".00";

        if(moneyValue-totalCost - int.Parse(payDebtInput.text) < 0){
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
        if(payDebt.isOn == false){
            debtWarning.SetActive(true);
        }
        else if(cantPay == true){
            //should not get here becaus of above, but just in cas
            print("warning about money");
        }
        else{
            MainManager.Instance.debt -= debtPaid;
            if(MainManager.Instance.debt > 0){
                MainManager.Instance.money -= totalCost + int.Parse(payDebtInput.text);
                MainManager.Instance.timeRemaining = MainManager.Instance.dayTime;
                MainManager.Instance.dayNum += 1;
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                FindFirstObjectByType<SceneController>().StartDay();
            }
            else{
                MainManager.Instance.SaveJsonData(MainManager.Instance);
                SceneManager.LoadScene("WinScreen");
            }
        }

    }

    void ToggleActivated(Toggle toggle, int cost){
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
        if(toggle.isOn){
            toggle.GetComponentInChildren<TMP_Text>().enabled = true;
        }
        else{
            toggle.GetComponentInChildren<TMP_Text>().enabled = false;
        }
    }

    void DebtInputChanged(Toggle toggle){
        if(toggle.isOn){
            toggle.GetComponentInChildren<TMP_Text>().text = "-$"+int.Parse(payDebtInput.text) + ".00";
        }
    }
}
