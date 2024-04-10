using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionButtons : MonoBehaviour
{
    public Image[] levelImages;
    public string buttonName;
    public Color newLevelColor;

    private Color redColor;
    private Color orangeColor;
    private Color yellowColor;
    private Color blueColor;
    private Color purpleColor;

    void Start() //makes the starting screen red
    {
        redColor = new Color(0.8584906f, 0.1093361f, 0.1093361f);
        orangeColor = new Color(0.9622642f, 0.4133903f, 0.1497864f);
        yellowColor = new Color(0.8584906f, 0.6467649f, 0f);
        blueColor = new Color(0.372549f, 0.7686275f, 0.7450981f);
        purpleColor = new Color(0.4588235f, 0.6134286f, 0.8784314f);

        buttonName = gameObject.name;
        for (int i = 0; i < levelImages.Length; i++)
        {
            levelImages[i].color = redColor;
        }
    }

    void Update() //makes the starting screen red
    {
        buttonName = gameObject.name;

        switch (buttonName)
        {
            case "Flowers Button":
                newLevelColor = redColor;
                break;
            case "Butterflies Button":
                newLevelColor = orangeColor;
                break;
            case "Bees Button":
                newLevelColor = yellowColor;
                break;
            case "Bumblebees Button":
                newLevelColor = blueColor;
                break;
            case "Other Button":
                newLevelColor = purpleColor;
                break;
        }
    }

    public void OnSectionButtonClicked()
    {
        for (int i = 0; i < levelImages.Length; i++)
        {
            levelImages[i].color = newLevelColor;
        }
    }
}
