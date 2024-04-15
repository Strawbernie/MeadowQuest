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
        StartCoroutine(TranslateDelay());
    }
    //App needs time to translate everything, this prevents inconsistency
    IEnumerator TranslateDelay()
    {
        yield return new WaitForSeconds(.2f);
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
