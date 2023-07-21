using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemInformation", menuName = "ScriptableObject/ItemInformation")]
public class ItemInformation : BaseInformation
{
    [Header("Name")]
    public string SushiName;

    [Header("Info")]
    public float Weight;
    public int Rank;
    public int Raiting;
    public int Price;
    public int Tasty;
    public int Length;

    [Header("Sprite")]
    public Sprite SushiSprite;
}
