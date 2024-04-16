using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguagePicker : MonoBehaviour
{
    public void pickedDutch()
    {
        LanguageManager.isDutch = true;
        Translator[] translations = Resources.FindObjectsOfTypeAll(typeof(Translator)) as Translator[];
        foreach (Translator translator in translations)
        {
            translator.OnValueChanged();
        }
    }
    public void pickedEnglish()
    {
        LanguageManager.isDutch = false;
        Translator[] translations = Resources.FindObjectsOfTypeAll(typeof(Translator)) as Translator[];
        foreach (Translator translator in translations)
        {
            translator.OnValueChanged();
        }
    }
}
