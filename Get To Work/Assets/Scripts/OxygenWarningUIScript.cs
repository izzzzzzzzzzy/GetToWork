using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OxygenWarningUIScript : MonoBehaviour
{
    public Button nextDayButton;
    public string nextLevelName;

    public Button closeWindow;
    public Toggle payDebt;

    public AudioSource buttonSFX;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = nextDayButton.GetComponent<Button>();
        btn.onClick.AddListener(Die);

        buttonSFX = buttonSFX.GetComponent<AudioSource>();

        Button closeWin = closeWindow.GetComponent<Button>();
        closeWindow.onClick.AddListener(GoBack);
        payDebt = payDebt.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die(){
        //TODO: go to death screen, reset scores and such
        buttonSFX.Play();
        SceneController.Instance.ChangeScene("DeathScreen");
        //FindFirstObjectByType<SceneController>().StartDay();
    }

    void GoBack(){
        buttonSFX.Play();
        payDebt.isOn = true;
        this.gameObject.SetActive(false);
    }
}
