using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    TextMeshProUGUI textToTranslate;
    string EnglishText;
    public string DutchText;
    void Start()
    {
      OnValueChanged();
    }

public void OnValueChanged()
    {
        textToTranslate = GetComponent<TextMeshProUGUI>();
        EnglishText = textToTranslate.text;
        if (LanguageManager.isDutch)
        {
            textToTranslate.text = DutchText;
        }
    }
}
