using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaManager : MonoBehaviour
{
    public GameObject encyclopediaCanvas;
    public GameObject levelCanvas;
    public GameObject filters;
    public RectTransform scrollView;
    public RectTransform scrollContent;
    public GameObject LooksLikePopUp;
    public GameObject SeasonPopUp;
    public GameObject ColorPopUp;
    bool filterOn;

    public void ResetButton()
    {
        List<ItemSlot> slots = new List<ItemSlot>();
        foreach (ItemSlot slot in Resources.FindObjectsOfTypeAll(typeof(ItemSlot)) as ItemSlot[])
        {
                slot.gameObject.SetActive(true);
        }
    }
    public void openEncyclopedia()
    {
        encyclopediaCanvas.SetActive(true);
        levelCanvas.SetActive(false);
    }
    public void closeEncyclopedia()
    {
        encyclopediaCanvas.SetActive(false);
        levelCanvas.SetActive(true);
    }
    public void filterButton()
    {
        if (!filterOn)
        {
            filters.SetActive(true);
            filterOn = true;
            scrollView.sizeDelta = new Vector2(1000, 1250);
            scrollContent.sizeDelta = new Vector2(-482, 725);
        }
        else
        {
            filters.SetActive(false);
            filterOn = false;
            scrollView.sizeDelta = new Vector2(1000, 1450);
            scrollContent.sizeDelta = new Vector2(-482, 925);
        }
    }
    public void LooksLike()
    {
        if (LooksLikePopUp.activeSelf)
        {
            LooksLikePopUp.SetActive(false);
        }
        else
        {
            LooksLikePopUp.SetActive(true);
            SeasonPopUp.SetActive(false);
            ColorPopUp.SetActive(false);
        }
    }
    public void LooksLikeButterfly()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if (slot.item.types != Item.Type.Butterfly)
            {
                slot.gameObject.SetActive(false);
            }
            else
            {
                slot.gameObject.SetActive(true);
            }
        }
        LooksLikePopUp.SetActive(false);
    }
    public void LooksLikeBee()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if (slot.item.types != Item.Type.Bee)
            {
                slot.gameObject.SetActive(false);
            }
            else
            {
                slot.gameObject.SetActive(true);
            }
        }
        LooksLikePopUp.SetActive(false);
    }
    public void LooksLikeFlower()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if (slot.item.types != Item.Type.Flower)
            {
                slot.gameObject.SetActive(false);
            }
            else
            {
                slot.gameObject.SetActive(true);
            }
        }
        LooksLikePopUp.SetActive(false);
    }
    public void Color()
    {
        if (ColorPopUp.activeSelf)
        {
            ColorPopUp.SetActive(false);
        }
        else
        {
            ColorPopUp.SetActive(true);
            SeasonPopUp.SetActive(false);
            LooksLikePopUp.SetActive(false);
        }
    }
    public void Orange()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Orange)!=0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Purple()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Purple) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Black()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Black) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void White()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.White) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Yellow()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Yellow) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Red()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Red) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Green()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Green) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Blue()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Blue) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Brown()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Brown) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Pink()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.colors & Item.Color.Pink) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        ColorPopUp.SetActive(false);
    }
    public void Season()
    {
        if (SeasonPopUp.activeSelf)
        {
            SeasonPopUp.SetActive(false);
        }
        else
        {
            SeasonPopUp.SetActive(true);
            ColorPopUp.SetActive(false);
            LooksLikePopUp.SetActive(false);
        }
    }
    public void Spring()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.seasons & Item.Season.Spring) != 0)
                {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        SeasonPopUp.SetActive(false);
    }
    public void Summer()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.seasons & Item.Season.Summer) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        SeasonPopUp.SetActive(false);
    }
    public void Autumn()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.seasons & Item.Season.Autumn) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        SeasonPopUp.SetActive(false);
    }
    public void Winter()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        foreach (ItemSlot slot in slots)
        {
            if ((slot.item.seasons & Item.Season.Winter) != 0)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
        }
        SeasonPopUp.SetActive(false);
    }
}
