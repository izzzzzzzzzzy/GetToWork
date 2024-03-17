using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DebtWarningUIScript : MonoBehaviour
{
    public Button nextDayButton;
    public string nextLevelName;

    public Button closeWindow;
    public Toggle payDebt;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = nextDayButton.GetComponent<Button>();
        btn.onClick.AddListener(Die);

        Button closeWin = closeWindow.GetComponent<Button>();
        closeWindow.onClick.AddListener(GoBack);
        payDebt = payDebt.GetComponent<Toggle>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die(){
        //TODO: go to death screen
        SceneManager.LoadScene(nextLevelName);
    }

    void GoBack(){
        payDebt.isOn = true;
        this.gameObject.SetActive(false);
    }
}
