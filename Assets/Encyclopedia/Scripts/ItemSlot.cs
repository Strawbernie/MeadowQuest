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
    private Image Image;
    // Start is called before the first frame update
    void Awake()
    {
        GatherInfo();
    }
    
    public void GatherInfo()
    {
        Image = GetComponent<Image>();
        Name.text = item.itemName;
        Description.text = item.itemDescription;
        Image.sprite = item.itemImage;
    }
}
