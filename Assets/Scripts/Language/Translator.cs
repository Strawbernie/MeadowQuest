using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    TextMeshProUGUI textToTranslate;
    public string DutchText;
    public string EnglishText;
    [HideInInspector] public bool shouldntTranslate;
    void Start()
    {
        textToTranslate = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TranslateDelay());
    }
    //App needs time to translate everything, this prevents inconsistency
    IEnumerator TranslateDelay()
    {
        yield return new WaitForSeconds(.01f);
        OnValueChanged();
    }

    public void OnValueChanged()
    {
        if (!shouldntTranslate)
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
}
