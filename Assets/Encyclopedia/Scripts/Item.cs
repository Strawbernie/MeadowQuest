using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EncyclopediaItem", menuName = "ScriptableObjects/EncyclopediaItem", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public enum Type {Butterfly, Bee, Flower}
    public enum Color { Orange, Red, Green, Blue, Purple, Yellow, Brown, Black, White, Pink }
    public enum Season { Spring, Summer, Autumn, Winter}

    public Type types;
    [Header("Colors")]
    public Color colors;
    [Header("If there are multiple relevant colors, pick those colors too")]
    public Color colors1;
    public Color colors2;

    [Header("Seasons")]
    public Season seasons;
    [Header("If there are multiple seasons, pick those seasons too")]
    public Season seasons1;
    public Season seasons2;
    public Season seasons3;

}
