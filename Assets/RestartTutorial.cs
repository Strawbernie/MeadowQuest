using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTutorial : MonoBehaviour
{
    public void restartTutorial()
    {
        LevelsUnlocked.TutorialUnlocked = false;
        foreach (Translator translator in Resources.FindObjectsOfTypeAll(typeof(Translator)) as Translator[])
        {
            translator.OnValueChanged();
        }
    }
}
