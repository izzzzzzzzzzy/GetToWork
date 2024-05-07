using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMinigame : MonoBehaviour
{
    public MinigameController miniController;

    [SerializeField] private int[] buttonOrder = {-1, -1, -1, -1, -1, -1, -1, -1};
    [SerializeField] private int difficulty = 1;
    [SerializeField] private int[] input = { -1, -1, -1, -1, -1, -1};
    private int placeInInput = 0;
    public Button[] buttons;

    [SerializeField] private bool showingButtons;
    private int placeInButtons = 0;
    private Color prevButColor;

    public Canvas correctFeedback;
    public Canvas incorrectFeedback;

    void Start(){
        showingButtons = true;
        miniController = miniController.GetComponent<MinigameController>();
        
        // Tried to do this scalably, did not work
        Button temp0 = buttons[0].GetComponent<Button>();
        temp0.onClick.AddListener(delegate {ButtonSelected(0);});

        Button temp1 = buttons[1].GetComponent<Button>();
        temp1.onClick.AddListener(delegate {ButtonSelected(1);});

        Button temp2 = buttons[2].GetComponent<Button>();
        temp2.onClick.AddListener(delegate {ButtonSelected(2);});

        Button temp3 = buttons[3].GetComponent<Button>();
        temp3.onClick.AddListener(delegate {ButtonSelected(3);});

        Button temp4 = buttons[4].GetComponent<Button>();
        temp4.onClick.AddListener(delegate {ButtonSelected(4);});

        Button temp5 = buttons[5].GetComponent<Button>();
        temp5.onClick.AddListener(delegate {ButtonSelected(5);});

        correctFeedback.GetComponent<Canvas>().gameObject.SetActive(false);
        incorrectFeedback.GetComponent<Canvas>().gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (miniController.gameStarted)
        {
            if (miniController.GetTimeRemaining() >= 0 && showingButtons)
            {
                if (placeInButtons <= buttons.Length)
                {
                    ScrambleButtonOrder();
                    Button x = buttons[buttonOrder[placeInButtons]].GetComponent<Button>();
                    prevButColor = x.image.color;
                    StartCoroutine(PlayButtons());
                    showingButtons = false;
                }
            }
        }
    }

    void ScrambleButtonOrder(){
        buttonOrder = new int[] {-1, -1, -1, -1, -1, -1, -1, -1};
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
        yield return new WaitForSeconds(1f);
        //change buttons color
        i = 0;
        while(i < buttonOrder.Length && buttonOrder[i] != -1){
            Button x = buttons[buttonOrder[i]].GetComponent<Button>();
            x.GetComponent<AudioSource>().Play();
            Color prevButColor = x.image.color;
            x.image.color = x.colors.pressedColor;
            yield return new WaitForSeconds(0.5f);
            x.image.color = prevButColor;
            yield return new WaitForSeconds(0.25f);
            i+=1;
        }
        //reactivate buttons
        i = 0;
        while(i < buttons.Length){
            buttons[i].GetComponent<Button>().interactable = true;
            i+=1;
        }
    }

    void ButtonSelected(int i){
        input[placeInInput] = i;
        placeInInput+=1;
        if(placeInInput > difficulty){
            bool areEqual = true;
            for(int j = 0; j < input.Length; j ++){
                if(input[j]!= buttonOrder[j]){
                    areEqual = false;
                }
            }
            if(areEqual){
                miniController.IncreaseScore(difficulty * 5);
                difficulty +=1;
                input = new int[] {-1, -1, -1, -1, -1, -1, -1, -1};
                placeInInput = 0;
                StartCoroutine(ShowFeedback(0));
                showingButtons = true;
            }
            else{
                input = new int[] {-1, -1, -1, -1, -1, -1, -1, -1};
                placeInInput = 0;
                StartCoroutine(ShowFeedback(1));
                showingButtons = true;
            }
        }
    }

    private IEnumerator ShowFeedback(int i){
        Canvas temp;
        if (i == 0){
            temp = correctFeedback.GetComponent<Canvas>();
        }
        else{
            temp = incorrectFeedback.GetComponent<Canvas>();
        }
        temp.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        temp.gameObject.SetActive(false);
    }
}
