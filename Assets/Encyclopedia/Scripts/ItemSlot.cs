using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    Translator translator;
    private Image Image;
    public bool unlockedItem;
    public GameObject notUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        if (unlockedItem)
        {
            notUnlocked.SetActive(false);
            GatherInfo();
        }
        else
        {
            Image = GetComponent<Image>();
            Name.gameObject.SetActive(false);
            Description.gameObject.SetActive(false);
            Image.sprite = item.blackoutImage;
            notUnlocked.SetActive(true);
        }
    }
    public void UpdateInfo()
    {
        if (unlockedItem)
        {
            GatherInfo();
        }
        else
        {
            Image = GetComponent<Image>();
            Name.gameObject.SetActive(false);
            Description.gameObject.SetActive(false);
            Image.sprite = item.blackoutImage;
        }
    }
    
    public void GatherInfo()
    {
        Name.gameObject.SetActive(true);
        Description.gameObject.SetActive(true);
        Image = GetComponent<Image>();
        Image.sprite = item.itemImage;
    }
}
