using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguagePicker : MonoBehaviour
{
    public GameObject LanguagePick;
    public void pickedDutch()
    {
        LanguageManager.isDutch = true;
        Translator[] translations = FindObjectsOfType<Translator>();
        foreach (Translator translator in translations)
        {
            translator.OnValueChanged();
        }
        LanguagePick.SetActive(false);
    }
    public void pickedEnglish()
    {
        LanguagePick.SetActive(false);
    }
}
