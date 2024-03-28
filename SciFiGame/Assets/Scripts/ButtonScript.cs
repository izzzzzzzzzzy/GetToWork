using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    SceneController sceneController;

    public Button startButton;
    public Button quitGameButton;
    public string nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        if(startButton != null){
            Button btn = startButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
        Button btn2 = quitGameButton.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(nextLevelName);
    }
    public void QuitGame(){
        if(SceneManager.GetActiveScene().name == "MainScene"){
            Application.Quit();
        }
        else{
            sceneController = FindFirstObjectByType<SceneController>();
            sceneController.EndMinigame(0);
            sceneController.PlayGame();

        }
    }

    public void LoadStartScreen(){
        SceneManager.LoadScene("StartScreen");
    }
}
