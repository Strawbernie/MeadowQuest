using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SectionButtons : MonoBehaviour
{
    public Image[] levelImages;
    public string buttonName;
    public Color newLevelColor;

    LevelUnlocker levelUnlocker;

    void Start() //makes the starting screen red
    {
        levelUnlocker = FindObjectOfType<LevelUnlocker>();

        buttonName = gameObject.name;
        for (int i = 0; i < levelImages.Length; i++)
        {
            LevelTransition button = levelImages[i].gameObject.GetComponent<LevelTransition>();
            button.finalName = button.screenOrSceneName + "Flower";
        }
    }

    public void OnSectionButtonClicked()
    {
        buttonName = gameObject.name;

        switch (buttonName)
        {
            case "Flowers Button":
                for (int i = 0; i < levelImages.Length; i++)
                {
                    LevelTransition button = levelImages[i].gameObject.GetComponent<LevelTransition>();
                    button.finalName = button.screenOrSceneName + "Flower";
                }
                levelUnlocker.UnlockedFlower();
                break;
            case "Butterflies Button":
                for (int i = 0; i < levelImages.Length; i++)
                {
                    LevelTransition button = levelImages[i].gameObject.GetComponent<LevelTransition>();
                    button.finalName = button.screenOrSceneName + "Butterfly";
                }
                levelUnlocker.UnlockedButterfly();
                break;
            case "Bees Button":
                for (int i = 0; i < levelImages.Length; i++)
                {
                    LevelTransition button = levelImages[i].gameObject.GetComponent<LevelTransition>();
                    button.finalName = button.screenOrSceneName + "Bee";
                }
                break;
            case "Bumblebees Button":
                for (int i = 0; i < levelImages.Length; i++)
                {
                    LevelTransition button = levelImages[i].gameObject.GetComponent<LevelTransition>();
                    button.finalName = button.screenOrSceneName + "Bumblebee";
                }
                break;
            case "Other Button":
                for (int i = 0; i < levelImages.Length; i++)
                {
                    LevelTransition button = levelImages[i].gameObject.GetComponent<LevelTransition>();
                    button.finalName = button.screenOrSceneName + "Other";
                }
                break;
        }
    }
}

