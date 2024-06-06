using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelUnlocked : MonoBehaviour
{

    public void Butterfly1Unlocked()
    {
        LevelsUnlocked.Butterfly1Unlocked = true;
    }
    public void Butterfly2Unlocked()
    {
        LevelsUnlocked.Butterfly2Unlocked = true;
    }
    public void Flower1Unlocked()
    {
        LevelsUnlocked.Flower1Unlocked = true;
    }
    public void Flower2Unlocked()
    {
        LevelsUnlocked.Flower2Unlocked = true;
    }
}
