using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    TextMeshProUGUI textToTranslate;
    public string DutchText;
    public string EnglishText;
    void Start()
    {
        textToTranslate = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TranslateDelay());
    }
    //App needs time to translate everything, this prevents inconsistency
    IEnumerator TranslateDelay()
    {
        yield return new WaitForSeconds(.1f);
        OnValueChanged();
    }

    public void OnValueChanged()
    {
        textToTranslate = GetComponent<TextMeshProUGUI>();
        if (LanguageManager.isDutch)
        {
            textToTranslate.text = DutchText;
        }
        else
        {
            textToTranslate.text = EnglishText;
        }
    }
}
