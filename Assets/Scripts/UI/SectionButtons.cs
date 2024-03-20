using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionButtons : MonoBehaviour
{
    public Image background;
    public string buttonName;
    public Color newBackgroundColor;

    void Start() //makes the starting screen red
    {
        buttonName = gameObject.name;
        background.color = new Color(0.909434f, 0.355194f, 0.355194f);
    }

    void Update() //makes the starting screen red
    {
        buttonName = gameObject.name;

        switch (buttonName)
        {
            case "Flowers Button":
                newBackgroundColor = new Color(0.909434f, 0.355194f, 0.355194f);
                break;
            case "Butterflies Button":
                newBackgroundColor = new Color(0.8593865f, 0.8784314f, 0.4588235f);
                break;
            case "Bees Button":
                newBackgroundColor = new Color(0.5438832f, 0.8784314f, 0.4588235f);
                break;
            case "Bumblebees Button":
                newBackgroundColor = new Color(0.4588235f, 0.8354726f, 0.8784314f);
                break;
            case "Other Button":
                newBackgroundColor = new Color(0.4588235f, 0.6134286f, 0.8784314f);
                break;
        }
    }

    public void OnSectionButtonClicked()
    {
        background.color = newBackgroundColor;
    }
}
