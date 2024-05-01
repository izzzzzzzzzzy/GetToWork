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

    private SpriteRenderer[] sprites;
    private int[] limbHealths;

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
        lArmText = lArmText.GetComponent<TMP_Text>();
        laImage = laImage.GetComponent<SpriteRenderer>();
        rArmText = rArmText.GetComponent<TMP_Text>();
        raImage = raImage.GetComponent<SpriteRenderer>();
        lLegText = lLegText.GetComponent<TMP_Text>();
        llImage = llImage.GetComponent<SpriteRenderer>();
        rLegText = rLegText.GetComponent<TMP_Text>();
        rlImage = rlImage.GetComponent<SpriteRenderer>();

        sprites = new SpriteRenderer[] { hImage, eImage, laImage, raImage, llImage, rlImage };
        limbHealths = MainManager.Instance.limbHealths;

        headText.text = "Head\n" + limbHealths[0] + "/100";
        eyeText.text = "Eye\n" + limbHealths[1] + "/100";
        lArmText.text = limbHealths[2] + "/100";
        rArmText.text = limbHealths[3] + "/100";
        lLegText.text = limbHealths[4] + "/100";
        rLegText.text = limbHealths[5] + "/100";

        for (int i = 0; i < 6; i++)
        {
            if (limbHealths[i] <= 30)
            {
                sprites[i].color = redColor;
            }
            else if (limbHealths[i] <= 70)
            {
                sprites[i].color = yellowColor;
            }
            else
            {
                sprites[i].color = greenColor;
            }
        }

    }

}
