using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LimbStatusDisplay : MonoBehaviour
{
    public TMP_Text headText;
    public Image hImage;
    public TMP_Text eyeText;
    public Image eImage;
    public TMP_Text rArmText;
    public Image raImage;
    public TMP_Text lArmText;
    public Image laImage;
    public TMP_Text rLegText;
    public Image rlImage;
    public TMP_Text lLegText;
    public Image llImage;

    private Image[] sprites;
    private int[] limbHealths;

    //36A81A
    private Color greenColor= Color.green;//new Color(54f, 168f, 26f);
    private Color yellowColor= Color.yellow;//new Color(238f, 241f, 42f);
    private Color redColor= Color.red;//new Color(241f, 51f, 42f);
    // Start is called before the first frame update
    void Start() { 

        sprites = new Image[] { hImage, eImage, laImage, raImage, llImage, rlImage };
        limbHealths = MainManager.Instance.limbHealths;

        headText.text = "Head\n" + limbHealths[0] + "/100";
        eyeText.text = "Eye\n" + limbHealths[1] + "/100";
        lArmText.text = "L. Arm\n" + limbHealths[2] + "/100";
        rArmText.text = "R. Arm\n" + limbHealths[3] + "/100";
        lLegText.text = "L. Leg\n" + limbHealths[4] + "/100";
        rLegText.text = "R. Leg\n" + limbHealths[5] + "/100";

        for (int i = 0; i < 6; i++)
        {
            //if (limbhealths[i] <= 30)
            //{
            //    sprites[i].color = redcolor;
            //}
            //else if (limbhealths[i] <= 70)
            //{
            //    sprites[i].color = yellowcolor;
            //}
            //else
            //{
            //    sprites[i].color = greencolor;
            //}
            float health = limbHealths[i] / 100f;
            sprites[i].color = new Color(2f * (1 - health), 2f * health, 0);
        }

    }

}
