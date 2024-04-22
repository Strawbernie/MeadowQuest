using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EncyclopediaItem", menuName = "ScriptableObjects/EncyclopediaItem", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;

    [Flags]
    public enum Type { None = 0, Butterfly = 1, Bee = 2, Flower = 4 }
    [Flags]
    public enum Color { None = 0, Orange = 1, Red = 2, Green = 4, Blue = 8, Purple = 16, Yellow = 32, Brown = 64, Black = 128, White = 256, Pink = 512 }
    [Flags]
    public enum Season { None = 0, Spring = 1, Summer = 2, Autumn = 4, Winter = 8 }

    [Header("What is it?")]
    public Type types;
    [Header("Colors")]
    public Color colors;
    [Header("Seasons")]
    public Season seasons;


}
