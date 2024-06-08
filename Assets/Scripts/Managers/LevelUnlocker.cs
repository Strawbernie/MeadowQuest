using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public GameObject LanguageScreen;
    public GameObject mainScreen;
    public GameObject tutorial;
    public GameObject[] levels;
    int levelsUnlockedButterfly = 1;
    int levelsUnlockedFlower = 1;
    public Sprite doneSprite;
    public Sprite unlockedSpriteButterfly;
    public Sprite unlockedSpriteFlower;
    public Sprite lockedSprite;

    private void Start()
    {
        if (LevelsUnlocked.TutorialUnlocked)
        {
            tutorial.SetActive(false);
            LanguageScreen.SetActive(false);
            mainScreen.SetActive(true);
        }
        UnlockedFlower();
    }
    public void UnlockedButterfly()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            Button button = levels[i].GetComponent<Button>();
            button.enabled = false;
            Image buttonSprite = button.gameObject.GetComponent<Image>();
            buttonSprite.sprite = lockedSprite;
            levelsUnlockedButterfly = 1;
        }
        if (LevelsUnlocked.Butterfly1Unlocked)
        {
            levelsUnlockedButterfly++;
        }
        if (LevelsUnlocked.Butterfly2Unlocked)
        {
            levelsUnlockedButterfly++;
        }
        for (int i = 0; i < Mathf.Min(levels.Length, levelsUnlockedButterfly); i++)
        {
            Button button = levels[i].GetComponent<Button>();
            button.enabled = true;
            Image buttonSprite = button.gameObject.GetComponent<Image>();
            buttonSprite.sprite = unlockedSpriteButterfly;
        }
        for (int i = 0; i < Mathf.Min(levels.Length, levelsUnlockedButterfly-1); i++)
        {
            Button button = levels[i].GetComponent<Button>();
            Image buttonSprite = button.gameObject.GetComponent<Image>();
            buttonSprite.sprite = doneSprite;
        }
    }
    public void UnlockedFlower()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            Button button = levels[i].GetComponent<Button>();
            button.enabled = false;
            Image buttonSprite = button.gameObject.GetComponent<Image>();
            buttonSprite.sprite = lockedSprite;
            levelsUnlockedFlower = 1;
        }
        if (LevelsUnlocked.Flower1Unlocked)
        {
            levelsUnlockedFlower++;
        }
        if (LevelsUnlocked.Flower2Unlocked)
        {
            levelsUnlockedFlower++;
        }
        for (int i = 0; i < Mathf.Min(levels.Length, levelsUnlockedFlower); i++)
        {
            Button button = levels[i].GetComponent<Button>();
            button.enabled = true;
            Image buttonSprite = button.gameObject.GetComponent<Image>();
            buttonSprite.sprite = unlockedSpriteFlower;
        }
        for (int i = 0; i < Mathf.Min(levels.Length, levelsUnlockedFlower - 1); i++)
        {
            Button button = levels[i].GetComponent<Button>();
            Image buttonSprite = button.gameObject.GetComponent<Image>();
            buttonSprite.sprite = doneSprite;
        }
    }
}
