using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LimbStatusDisplay : MonoBehaviour
{
    public TMP_Text headText;
    public SpriteRenderer hImage;
    public TMP_Text eyeText;
    public SpriteRenderer eImage;
    public TMP_Text rArmText;
    public SpriteRenderer raImage;
    public TMP_Text lArmText;
    public SpriteRenderer laImage;
    public TMP_Text rLegText;
    public SpriteRenderer rlImage;
    public TMP_Text lLegText;
    public SpriteRenderer llImage;

    //36A81A
    private Color greenColor= Color.green;//new Color(54f, 168f, 26f);
    private Color yellowColor= Color.yellow;//new Color(238f, 241f, 42f);
    private Color redColor= Color.red;//new Color(241f, 51f, 42f);
    // Start is called before the first frame update
    void Start()
    {
        headText = headText.GetComponent<TMP_Text>();
        hImage = hImage.GetComponent<SpriteRenderer>();
        eyeText = eyeText.GetComponent<TMP_Text>();
        eImage = eImage.GetComponent<SpriteRenderer>();
        rArmText = rArmText.GetComponent<TMP_Text>();
        raImage = raImage.GetComponent<SpriteRenderer>();
        lArmText = lArmText.GetComponent<TMP_Text>();
        laImage = laImage.GetComponent<SpriteRenderer>();
        rLegText = rLegText.GetComponent<TMP_Text>();
        rlImage = rlImage.GetComponent<SpriteRenderer>();
        lLegText = lLegText.GetComponent<TMP_Text>();
        llImage = llImage.GetComponent<SpriteRenderer>();

        headText.text = "Head\n" + MainManager.Instance.headHealth + "/100";
        eyeText.text = "Eye\n" + MainManager.Instance.eyeHealth + "/100";
        rArmText.text = MainManager.Instance.rArmHealth + "/100";
        lArmText.text = MainManager.Instance.lArmHealth + "/100";
        rLegText.text = MainManager.Instance.rLegHealth + "/100";
        lLegText.text = MainManager.Instance.lLegHealth + "/100";

        if(MainManager.Instance.headHealth <= 30){
            hImage.color = redColor;
        }
        else if(MainManager.Instance.headHealth <= 70){
            hImage.color = yellowColor;
        }
        else{
            hImage.color = greenColor;
        }

        if(MainManager.Instance.eyeHealth <= 30){
            eImage.color = redColor;
        }
        else if(MainManager.Instance.eyeHealth <= 70){
            eImage.color = yellowColor;
        }
        else{
            eImage.color = Color.blue;
        }

        if(MainManager.Instance.rArmHealth <= 30){
            raImage.color = redColor;
        }
        else if(MainManager.Instance.rArmHealth <= 70){
            raImage.color = yellowColor;
        }
        else{
            raImage.color = greenColor;
        }

        if(MainManager.Instance.lArmHealth <= 30){
            laImage.color = redColor;
        }
        else if(MainManager.Instance.lArmHealth <= 70){
            laImage.color = yellowColor;
        }
        else{
            laImage.color = greenColor;
        }

        if(MainManager.Instance.rLegHealth <= 30){
            rlImage.color = redColor;
        }
        else if(MainManager.Instance.rLegHealth <= 70){
            rlImage.color = yellowColor;
        }
        else{
            rlImage.color = greenColor;
        }

        if(MainManager.Instance.lLegHealth <= 30){
            llImage.color = redColor;
        }
        else if(MainManager.Instance.lLegHealth <= 70){
            llImage.color = yellowColor;
        }
        else{
            llImage.color = greenColor;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
