using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    public GameObject[] levels;
    int levelsUnlockedButterfly = 1;
    int levelsUnlockedFlower = 1;

    private void Start()
    {
        UnlockedFlower();
    }
    public void UnlockedButterfly()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
            levelsUnlockedButterfly = 1;
        }
        if (LevelsUnlocked.Butterfly2Unlocked)
        {
            levelsUnlockedButterfly++;
        }
        for (int i = 0; i < Mathf.Min(levels.Length, levelsUnlockedButterfly); i++)
        {
            levels[i].SetActive(true);
        }
    }
    public void UnlockedFlower()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        for (int i = 0; i < Mathf.Min(levels.Length, levelsUnlockedFlower); i++)
        {
            levels[i].SetActive(true);
        }
    }
}
