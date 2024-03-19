using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMinigame : MonoBehaviour
{
    SceneController controller;

    [SerializeField] private float gameTime = 60f;
    //[SerializeField] private float target = 20f;
    [SerializeField] private float score;
    [SerializeField] private int[] buttonOrder = {-1, -1, -1, -1, -1, -1};
    [SerializeField] private int difficulty = 1;
    public GameObject[] buttons;

    [SerializeField] private bool showingButtons;
    private int placeInButtons = 0;
    private Color prevButColor;
    private bool gameOver;

    void Start(){
        showingButtons = true;
    }
    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime < 0 && !gameOver)
        {
            gameOver = true;

            controller = FindFirstObjectByType<SceneController>();
            controller.EndMinigame();
        }

        if(gameTime >= 0 && showingButtons){
            if(placeInButtons <= buttons.Length){
                ScrambleButtonOrder();
                Button x = buttons[buttonOrder[placeInButtons]].GetComponent<Button>();
                prevButColor = x.image.color;
                StartCoroutine(PlayButtons());
                showingButtons = false;
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void DecreaseScore()
    {
        score--;
    }

    void ScrambleButtonOrder(){
        buttonOrder = new int[] {-1, -1, -1, -1, -1, -1};
        int i = 0;
        while(i <= difficulty){
            buttonOrder[i] = Random.Range(0, buttons.Length);
            i+=1;
        }

        i = 0;
    }

    //NOT working
    public IEnumerator PlayButtons(){
        int i = 0;
        //deactivate buttons
        while(i < buttons.Length){
            buttons[i].GetComponent<Button>().interactable = false;
            i+=1;
        }
        yield return new WaitForSeconds(0.5f);
        //change buttons color
        i = 0;
        while(i < buttonOrder.Length && buttonOrder[i] != -1){
            Button x = buttons[buttonOrder[i]].GetComponent<Button>();
            Color prevButColor = x.image.color;
            x.image.color = x.colors.pressedColor;
            yield return new WaitForSeconds(1);
            x.image.color = prevButColor;
            yield return new WaitForSeconds(0.5f);
            i+=1;
        }
        //reactivate buttons
        i = 0;
        while(i < buttons.Length){
            buttons[i].GetComponent<Button>().interactable = true;
            i+=1;
        }
    }
}
