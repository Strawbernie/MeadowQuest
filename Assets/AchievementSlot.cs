using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AchievementSlot : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    Translator translator;
    private Image Image;
    public Sprite badgeIcon;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        GatherInfo();
    }
    public void UpdateInfo()
    {
            GatherInfo();
    }

    public void GatherInfo()
    {
        Image = GetComponent<Image>();
        Image.enabled = true;
        Name.gameObject.SetActive(true);
        Description.gameObject.SetActive(true);
        Image.sprite = badgeIcon;
    }
}
