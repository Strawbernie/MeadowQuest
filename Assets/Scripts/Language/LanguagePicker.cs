using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguagePicker : MonoBehaviour
{
    public GameObject canvas;
    public GameObject mainScreen;
    private void Awake()
    {
        ItemSlot[] itemSlots = Resources.FindObjectsOfTypeAll(typeof(ItemSlot)) as ItemSlot[];
        foreach (ItemSlot itemSlot in itemSlots)
        {
            itemSlot.GatherInfo();
        }
    }
    public void pickedDutch()
    {
        LanguageManager.isDutch = true;
        Translator[] translations = Resources.FindObjectsOfTypeAll(typeof(Translator)) as Translator[];
        foreach (Translator translator in translations)
        {
            translator.OnValueChanged();
        }
        canvas.SetActive(false);
        mainScreen.SetActive(true);
    }
    public void pickedEnglish()
    {
        LanguageManager.isDutch = false;
        Translator[] translations = Resources.FindObjectsOfTypeAll(typeof(Translator)) as Translator[];
        foreach (Translator translator in translations)
        {
            translator.OnValueChanged();
        }
        canvas.SetActive(false);
        mainScreen.SetActive(true);
    }
}
