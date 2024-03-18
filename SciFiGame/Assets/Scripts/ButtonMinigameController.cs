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
    private float startShowingTimer = -1;
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
            if(startShowingTimer == -1 && placeInButtons <= buttons.Length){
                //ScrambleButtonOrder();
                startShowingTimer += Time.deltaTime;
                print("aa");
            }/*
            else if(startShowingTimer >= 1 && placeInButtons <= buttons.Length){
                //if reached end of time for button to be colored
                Button x = buttons[buttonOrder[placeInButtons]].GetComponent<Button>();
                x.image.color = prevButColor;
                placeInButtons +=1;
                //if not reached end of list
                if(placeInButtons < buttons.Length){
                    x = buttons[buttonOrder[placeInButtons]].GetComponent<Button>();
                    prevButColor = x.image.color;
                }
                startShowingTimer = 0;
            }
            else if(placeInButtons <= buttons.Length){
                // if still showing buttons
                Button x = buttons[buttonOrder[placeInButtons]].GetComponent<Button>();
                x.image.color = x.colors.pressedColor;
                startShowingTimer += Time.deltaTime;
            }
            else{
                startShowingTimer = -1;
                placeInButtons = 0;
                showingButtons = false;
            }*/
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
        print("scramble 1");
        buttonOrder = new int[] {-1, -1, -1, -1, -1, -1};
        int i = 0;
        while(i <= difficulty){
            print("scramble 2");
            buttonOrder[i] = Random.Range(0, buttons.Length);
            i+=1;
        }

        i = 0;
        //deactivate buttons
        while(i < buttons.Length){
            print("scramble 3: deactivating");
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    //NOT working
    /*
    public IEnumerator PlayButtons(){
        print("play 1");
        int i = 0;
        //deactivate buttons
        while(i < buttons.Length){
            print("play 2: deactivating");
            buttons[i].GetComponent<Button>().interactable = false;
        }
        //change buttons color
        i = 0;
        while(i < buttonOrder.Length){
            Button x = buttons[buttonOrder[i]].GetComponent<Button>();
            Color prevButColor = x.image.color;
            x.image.color = x.colors.pressedColor;
            print("play 3a");
            yield return new WaitForSeconds(5);
            print("play 3b");
            x.image.color = prevButColor;
            //yield return new WaitForSeconds(3);
            print("play 3c");
            i++;
        }
        //reactivate buttons
        i = 0;
        while(i < buttons.Length){
            print("play 4: activating");
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }*/
}
