using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FishInformation", menuName = "ScriptableObject/FishInformation")]
public class FishInformation : BaseInformation
{
    [Header("Name")]
    public string SushiName;

    [Header("Info")]
    public float Weight;
    public int Rank;
    public int Raiting;
    public int Price;

    [Header("Sprite")]
    public Sprite SushiSprite;
}
