using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseUISlot : ItemSlot
{
    [Header("Fish Info")]
    [SerializeField] private TextMeshProUGUI Weight;
    [SerializeField] private Star Star;
    public override void Init(ItemInformation info)
    {
        base.Init(info);
        Rank.text = $"Rank<b><color=#487690><size=30>{info.Rank}";
        Weight.text = $"{info.Weight} <color=#487690>kg";
        Star.StarOn(info.Raiting);
    }
}
